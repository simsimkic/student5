using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorController
    {
        public List<Doctor> GetAvailableDoctors(DateTime time)
        {
            throw new NotImplementedException();
        }
        public String DoctorRegistration(Doctor doctor)
        {
            try
            {
                doctorService.DoctorRegistration(doctor);
                return "Successful registration";
            }
            catch (EmptyFieldException e)
            {
                return "Field " + e.FieldName + " must not be empty";
            }
            catch (JmbgInvalidException e)
            {
                return "JMBG must contain exactly 13 digits";
            }
            catch (JmbgNotUniqueException e)
            {
                return "JMBG not unique";
            }
        }


        public List<(DateTime, DateTime, Doctor)> PriorityDoctorForAppointment(DateTime begin, DateTime end,Doctor doctor)
        {
            return doctorService.GetAvailablePeriods(begin, end, doctor);
        }

        public List<(DateTime, DateTime)> GetAvailablePeriods(int doctorId)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsFromWorkingTime(WorkingTime workingTime)
        {
            return doctorService.GetDoctorsFromWorkingTime(workingTime);
        }

        public AppointmentReport CreateAppointmentReport(String opinion, String diagnosis, String disease, String chronicDisease, int appointmentId)
        {
            throw new NotImplementedException();
        }

        public WorkingTime ChangeWorkingTime(WorkingTime workingTime)
        {
            throw new NotImplementedException();
        }

        public List<NotificationDoctor> GetDoctorNotification(int doctorId)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorBySpecialist(Boolean specialist)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorService.GetAllDoctors();
        }
        public String DeactivateDoctorAccount(Doctor doctor)
        {
            doctorService.DeactivateDoctorAccount(doctor);
            return "Account successfuly deactivated!";
        }
        public DoctorService doctorService = new DoctorService();

    }
}