using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AppointmentService
    {
        public Appointment UpdateAppointmentTime(Appointment appointment, DateTime time)
        {
            UtilityService.ValidateSelectedTime(time);
            appointment.Time = time;
            appointmentRepository.Update(appointment);
            
            return appointment;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            ValidateAppointmentInformation(appointment);
            appointmentRepository.Create(appointment);
            return appointment;
        }

        public void ValidateAppointmentInformation(Appointment appointment)
        {
            if (appointment.Patient == null) throw new EmptyFieldException("Patient can't be null");
            if (appointment.Doctor == null) throw new EmptyFieldException("Doctor can't be null");
            UtilityService.ValidateSelectedTime(appointment.Time);
            UtilityService.ValidateDurationTimeValid(appointment.Duration);
        }


        public List<(DateTime, DateTime, Doctor)> CalculateAvailableTimesForSelectedPeriods(DateTime begin, DateTime end)
        {
            List<Doctor> activeDoctors = doctorRepository.GetDoctorsWithActiveAccounts();
            List<(DateTime, DateTime,Doctor)> availableTimes = new List<(DateTime, DateTime, Doctor)>();
            foreach (Doctor doctor in activeDoctors)
            {
                availableTimes.AddRange(doctorService.GetAvailablePeriods(begin, end, doctor));
            }
            return availableTimes;
        }

        internal void PatientCancelAppointment(Appointment appointment)
        {
            if (UtilityService.IsTimeValidForCancel(appointment.Time))
                CancelAppointment(appointment);
            else 
                throw new InvalidTimeForAppointmentCancelation("You can not cancel appointment which has date 2 days from now.");
        }

        public void CancelAppointment(Appointment appointment)
        {
            if (appointment != null)
            {
                UtilityService.ValidateSelectedTime(appointment.Time);
                appointmentRepository.Delete(appointment.Id);
            }
            else
                throw new Exception();
        }


        public List<Appointment> GetAppointmentsForPatient(Patient patient)
        {
            return appointmentRepository.GetAppointmentsForPatient(patient);
        }

        public List<Appointment> GetPatientScheduledAppointments(Patient patient)
        {
            return appointmentRepository.GetPatientScheduledAppointments(patient);    
        }

        public Appointment UpdateDurationTime(TimeSpan duration, Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsForDoctor(Doctor doctor)
        {
            return this.appointmentRepository.GetAppointmentsByDoctorId(doctor.Id);
        }

        public Appointment CreateOperationAppointment(Doctor doctor, Patient patient, DateTime time)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllScheduledAppointments()
        {
            return appointmentRepository.GetAllScheduledAppointments();
        }

        public AppointmentReport GetAppointmentReport(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Boolean IsChoosenPeriodAvailable(DateTime time)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentByTimeAndDoctor(DateTime time, Doctor doctor, TimeSpan duration)
        {
            List<Appointment> appointments = GetAllScheduledAppointments();
            foreach (Appointment appointment in appointments)
                if (appointment.Doctor != null)
                    if (appointment.Doctor.PersonalNumber == doctor.PersonalNumber)
                    {
                        if (time >= appointment.Time & time <= appointment.Time.Add(appointment.Duration)) return appointment;
                        else if (time.Add(duration) >= appointment.Time & time.Add(duration) <= appointment.Time.Add(appointment.Duration)) return appointment;
                    }
            return null;
        }
        public Appointment GetAppointment(int appointmentId)
        {
            return appointmentRepository.GetById(appointmentId);
        }



        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public DoctorRepository doctorRepository = new DoctorRepository();
        public PatientService patientService = new PatientService();
        public DoctorService doctorService = new DoctorService();
        public RoomService roomService;

    }
}