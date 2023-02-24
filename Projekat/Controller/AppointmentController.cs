using Hospital.Exception;
using Model;
using Newtonsoft.Json.Serialization;
using Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Controller
{
    public class AppointmentController
    {
        public String UpdateAppointmentTime(Appointment appointment, DateTime time)
        {
            try
            {
                appointmentService.UpdateAppointmentTime(appointment, time);
                return "sucess";
            }
            catch(InvalidDateException e)
            {
                return e.Message;
            }
            catch (EmptyFieldException e)
            {
                return e.Message;
            }
        }

       
        public string CreateAnAppointment(Appointment appointment)
        {
            try
            {
                appointmentService.CreateAppointment(appointment);
                return "Successfully created appointment.";
            }
            catch(InvalidDateException e)
            {
                return e.Message;
            }
            catch(InvalidDurationException e)
            {
                return e.Message;
            }
            catch(EmptyFieldException e)
            {
                return e.Message;
            }
        }

        public List<(DateTime, DateTime, Doctor)> PriorityTimeForAppointment(DateTime begin, DateTime end)
        {
           return  appointmentService.CalculateAvailableTimesForSelectedPeriods(begin, end);
        }



        public String CancelAppointment(Appointment appointment)
        {
            try
            {
                appointmentService.CancelAppointment(appointment);
                return "success";
            }
            catch (InvalidDateException e)
            {
                return e.Message;
            }
            catch(EmptyFieldException e)
            {
                return e.Message;
            }
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsForPatient(Patient patient)
        {
            return appointmentService.GetAppointmentsForPatient(patient);
        }

        public List<Appointment> GetPatientScheduledAppointments(Patient patient)
        {
            try
            {
                UtilityService.CheckUserForNull(patient);
                return appointmentService.GetPatientScheduledAppointments(patient);
            } catch (NullReferenceException e) {
                throw new NullReferenceException();
            } 
        }

        public Appointment UpdateDurationTime(TimeSpan duration, int appointmentId)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsForDoctor(Doctor doctor)
        {
            
            return this.appointmentService.GetAppointmentsForDoctor(doctor);
            
        }

        public String CreateOperationAppointment(Appointment appointment)
        {
            if (appointment.Doctor.Specialist)
            {
                appointment.Operation = true;
                return CreateEmergencyAppointment(appointment);
            }
            else
            {
                return "Doctor needs to be specialist!";
            }
        }

        public string CreateEmergencyAppointment(Appointment appointment)
        {
            appointment.Emergency = true;
            String ret = CreateAnAppointment(appointment);
            Appointment appointmentForUpdating = appointmentService.GetAppointmentByTimeAndDoctor(appointment.Time, appointment.Doctor, appointment.Duration);
            if (appointmentForUpdating != null)
            {
                List<(DateTime, DateTime, Doctor)> availablePeriods = appointmentService.CalculateAvailableTimesForSelectedPeriods(appointmentForUpdating.Time, appointmentForUpdating.Time.Add(appointmentForUpdating.Duration));
                if (availablePeriods.Count != 0) appointmentService.UpdateAppointmentTime(appointmentForUpdating, availablePeriods[0].Item1);
                else appointmentService.CancelAppointment(appointmentForUpdating);
            }
            return ret;
        }

        public List<Appointment> GetAllScheduledAppointments()
        {
            return appointmentService.GetAllScheduledAppointments();
        }

        public AppointmentReport GetAppointmentReport(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return appointmentService.GetAppointment(appointmentId);
        }


        public AppointmentService appointmentService = new AppointmentService();

    }
}