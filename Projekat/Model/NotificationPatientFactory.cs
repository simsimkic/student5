using System;

namespace Model
{
   public class NotificationPatientFactory : NotificationFactory
   {
      public new Notification CreateNotification()
      {
         throw new NotImplementedException();
      }
      
      public NotificationPatientFactory(DateTime canceledAppointmentTime, DateTime newAppointmentTime)
      {
         throw new NotImplementedException();
      }
   
   }
}