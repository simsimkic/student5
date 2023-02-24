using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class GuestAppointmentRepository : GenericRepository<GuestAppointment>
   {
      public List<GuestAppointment> GetAllScheduledGuestAppointments()
      {
            List<GuestAppointment> scheduledAppointemts = new List<GuestAppointment>();
            foreach (GuestAppointment guestAppointment in GetAll())
            {
                if (guestAppointment.IsInFuture())
                    scheduledAppointemts.Add(guestAppointment);
            }
            return scheduledAppointemts;
        }
      
      public List<GuestAppointment> GetGuestAppointmentsByTime(TimeSpan time)
      {
         throw new NotImplementedException();
      }
   
   }
}