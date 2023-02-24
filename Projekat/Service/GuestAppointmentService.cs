using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class GuestAppointmentService
   {
      public Boolean IsChoosenPeriodAvailable(DateTime time)
      {
         throw new NotImplementedException();
      }
      
      public GuestAppointment CreateGuestAppointment(GuestAppointment guestAppointment)
      {
            UtilityService.ValidateSelectedTime(guestAppointment.Time);
            UtilityService.ValidateDurationTimeValid(guestAppointment.Duration);
            guestAppointmentRepository.Create(guestAppointment);
            return guestAppointment;
        }

        public void ValidateGuestAppointmentInformation(GuestAppointment guestAppointment)
        {
            if (guestAppointment.Guest == null) throw new EmptyFieldException("Guest can't be null");
            if (guestAppointment.Doctor == null) throw new EmptyFieldException("Doctor can't be null");
            UtilityService.ValidateSelectedTime(guestAppointment.Time);
            UtilityService.ValidateDurationTimeValid(guestAppointment.Duration);
        }


        public GuestAppointment UpdateGuestAppointmentTime(GuestAppointment guestAppointment, DateTime time)
      {
            if (guestAppointment == null) throw new EmptyFieldException("Appointment can't be null");
            UtilityService.ValidateSelectedTime(time);
            guestAppointment.Time = time;
            guestAppointmentRepository.Update(guestAppointment);
            return guestAppointment;
        }
      
      public void CancelGuestAppointment(GuestAppointment guestAppointment)
      {
            if (guestAppointment.Guest == null) throw new EmptyFieldException("Guest can't be null");
            UtilityService.ValidateSelectedTime(guestAppointment.Time);
            guestAppointmentRepository.Delete(guestAppointment.Id);
        }
      
      public GuestAppointment UpdateDurationTime(TimeSpan duration, GuestAppointment guestAppointment)
      {
         throw new NotImplementedException();
      }

        public List<GuestAppointment> GetAllScheduledGuestAppointments()
        {
            return guestAppointmentRepository.GetAllScheduledGuestAppointments();
        }


      public List<Appointment> GetGuestAppointmentsForDoctor(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Boolean IsDurationTimeValid(DateTime duration)
      {
         throw new NotImplementedException();
      }

        public GuestAppointment GetGuestAppointment(int guestAppointmentId)
        {
            return guestAppointmentRepository.GetById(guestAppointmentId);
        }

        public GuestAppointmentRepository guestAppointmentRepository = new GuestAppointmentRepository();
      public RoomService roomService;
   
   }
}