using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorService
    {
        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAll();
        }

        public void DoctorLogin(string email, string password)
        {
            userService.Login(email, password);
            Doctor doctor = doctorRepository.GetByEmailAndPassword(email, password);
            UtilityService.CheckUserForNull(doctor);
        }

        public Doctor DoctorRegistration(Doctor doctor)
        {
            userService.ValidateRegistrationInformation(doctor);
            InitializeFields(ref doctor);
            ValidateDoctorInfo(doctor);
            utilityService.ValidatePersonalNumberUnique(doctor);
            doctorRepository.Create(doctor);
            return doctor;
        }

        public List<Doctor> GetDoctorsFromWorkingTime(WorkingTime workingTime)
        {
            return doctorRepository.GetDoctorsByWorkingTime(workingTime);
        }
        public void ValidateDoctorInfo(Doctor doctor)
        {   
            //if (doctor.Appointment.Equals(null)) throw new EmptyFieldException("Appointment");
            if (doctor.Specialist.Equals(null)) throw new EmptyFieldException("Specialist");
            //if (doctor.GuestAppointment.Equals(null)) throw new EmptyFieldException("Guest Appointment list");
            if (doctor.WorkingTime.Equals(null)) throw new EmptyFieldException("Working Time");
        }
        public void InitializeFields(ref Doctor doctor)
        {
            doctor.Active = true;
        }

        public List<(DateTime, DateTime, Doctor)> GetAvailablePeriods(DateTime begin, DateTime end, Doctor doctor)
        {
            List<(DateTime, DateTime, Doctor)> availablePeriods = new List<(DateTime, DateTime, Doctor)>();
            
            foreach(Appointment appointment in appointmentRepository.GetAllScheduledAppointments())
                if(appointment.Doctor != null)
                    if (appointment.Doctor.PersonalNumber == doctor.PersonalNumber)
                        for (DateTime current = begin; current < end;)
                        {
                            if (appointment.Time > current & current.AddMinutes(15) < appointment.Time) availablePeriods.Add((current, current.AddMinutes(15), appointment.Doctor));
                            else if (appointment.Time.AddMinutes(appointment.Duration.TotalMinutes) < current)
                            {
                                current = appointment.Time.AddMinutes(appointment.Duration.TotalMinutes);
                                availablePeriods.Add((current, current.AddMinutes(15), appointment.Doctor));
                            }
                            current = current.AddMinutes(15);
                        }
            
            foreach ((DateTime, DateTime, Doctor) available in GetAvailablePeriodsForDoctorsWithoutAppointment(begin, end))
                availablePeriods.Add(available);
            return availablePeriods;
        }

        public List<(DateTime, DateTime, Doctor)> GetAvailablePeriodsForDoctorsWithoutAppointment(DateTime begin, DateTime end)
        {
            List<(DateTime, DateTime, Doctor)> availablePeriods = new List<(DateTime, DateTime, Doctor)>();

            foreach (Doctor doctor in GetDoctorsWithoutAppointments())
                for (DateTime current = begin; current < end;)
                {
                    availablePeriods.Add((current, current.AddMinutes(15), doctor));
                    current = current.AddMinutes(15);
                }
            return availablePeriods;
        }
        public void UpdateDoctor(Doctor doctor)
        {
            UtilityService.CheckUserForNull(doctor);
            userService.ValidateRegistrationInformation(doctor);
            doctorRepository.Update(doctor);
        }

        public List<Doctor> GetDoctorsWithoutAppointments()
        {
            List<Doctor> allDoctors = doctorRepository.GetDoctorsWithActiveAccounts();
            List<Appointment> scheduledAppointments = appointmentRepository.GetAllScheduledAppointments();
            List<Doctor> doctorsWithoutAppointments = new List<Doctor>();
            foreach(Doctor doctor in allDoctors)
            {
                int count = 0;
                foreach (Appointment appointment in scheduledAppointments)
                    if(appointment.Doctor != null)
                        if (appointment.Doctor.Id == doctor.Id) count++;
                if (count == 0) doctorsWithoutAppointments.Add(doctor);
            }
            return doctorsWithoutAppointments;
        }


        public AppointmentReport CreateAppointmentReport(AppointmentReport appointmentReport)
        {
            throw new NotImplementedException();
        }

        public WorkingTime UpdateWorkingTime(WorkingTime workingTime)
        {
            throw new NotImplementedException();
        }

        public List<NotificationDoctor> GetDoctorNotification(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAvailableDoctors(DateTime time)
        {
            //List<Doctor> doctors = doctorRepository.GetAll();
            //foreach(Doctor doctor in doctors)
            //{
                
            //}
            throw new NotImplementedException();
        }
        public void DeactivateDoctorAccount(Doctor doctor)
        {
            doctor.Active = false;
            CancelDoctorAppointments(doctor);
            doctorRepository.Update(doctor);
        }
        public void CancelDoctorAppointments(Doctor doctor)
        {
            List<Appointment> allAppointments = appointmentRepository.GetAll();
            List<GuestAppointment> allGuestAppointments = guestAppointmentRepository.GetAll();

            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Doctor != null && appointment.Doctor.Id == doctor.Id) appointmentRepository.Delete(appointment.Id);
            }
            foreach (GuestAppointment guestAppointment in allGuestAppointments)
            {
                if (guestAppointment.Doctor != null && guestAppointment.Doctor.Id == doctor.Id) appointmentRepository.Delete(guestAppointment.Id);
            }
        }
        public List<Doctor> GetDoctorBySpecialist(Boolean specialist)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetDoctorNotifications()
        {
            throw new NotImplementedException();
        }
        public UserService userService = new UserService();
        public DoctorRepository doctorRepository = new DoctorRepository();
        public NotificationDoctorRepository notificationDoctorRepository;
        public UtilityService utilityService = new UtilityService();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public GuestAppointmentRepository guestAppointmentRepository = new GuestAppointmentRepository();
    }
}