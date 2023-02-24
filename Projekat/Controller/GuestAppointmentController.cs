using Hospital.Exception;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class GuestAppointmentController
   {
      public String CreateGuestAppointment(GuestAppointment guestAppointment)
      {
            try
            {
                guestAppointmentService.CreateGuestAppointment(guestAppointment);
                return "success";
            }
            catch (InvalidDateException e)
            {
                return "Invalid date, date needs to be in the future";
            }
            catch (InvalidDurationException e)
            {
                return "Invalid duration time";
            }
            catch (EmptyFieldException e)
            {
                return e.Message;
            }
        }
      
      public String UpdateGuestAppointmentTime(GuestAppointment guestAppointment, DateTime time)
      {
            try
            {
                guestAppointmentService.UpdateGuestAppointmentTime(guestAppointment, time);
                return "success";
            }
            catch (InvalidDateException e)
            {
                return e.Message;
            }
            catch (EmptyFieldException e)
            {
                return e.Message;
            }
        }
      
      public String CancelGuestAppointment(GuestAppointment guestAppointment)
      {
            try
            {
                guestAppointmentService.CancelGuestAppointment(guestAppointment);
                return "success";
            }
            catch (InvalidDateException e)
            {
                return e.Message;
            }
            catch (EmptyFieldException e)
            {
                return e.Message;
            }
        }
      
      public GuestAppointment UpdateDurationTime(TimeSpan duration, int guestAppointmentId)
      {
         throw new NotImplementedException();
      }

      public List<GuestAppointment> GetAllScheduledGuestAppointments()
      {
            return guestAppointmentService.GetAllScheduledGuestAppointments();
      }

        public List<Appointment> GetGuestAppointmentsForDoctor(int doctorId)
      {
         throw new NotImplementedException();
      }
      
      public string CreateEmergencyGuestAppointment(GuestAppointment guestAppointment)
      {
            guestAppointment.Emergency = true;
            String ret =  CreateGuestAppointment(guestAppointment);
            Appointment appointmentForUpdating = appointmentService.GetAppointmentByTimeAndDoctor(guestAppointment.Time, guestAppointment.Doctor, guestAppointment.Duration);
            if (appointmentForUpdating != null)
            {
                List<(DateTime, DateTime, Doctor)> availablePeriods = appointmentService.CalculateAvailableTimesForSelectedPeriods(appointmentForUpdating.Time, appointmentForUpdating.Time.Add(appointmentForUpdating.Duration));
                if (availablePeriods.Count != 0)
                    appointmentService.UpdateAppointmentTime(appointmentForUpdating, availablePeriods[0].Item1);
                else
                    appointmentService.CancelAppointment(appointmentForUpdating);
            }
            return ret;
        }
      
      public GuestAppointment GetGuestAppointmentById(int guestAppointmentId)
      {
            return guestAppointmentService.GetGuestAppointment(guestAppointmentId);
      }

        public GuestAppointmentService guestAppointmentService = new GuestAppointmentService();
        public AppointmentService appointmentService = new AppointmentService();
     
     
   }
}