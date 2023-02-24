using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class NotificationDoctorService : INotification
   {
      public void CreateNotification(NotificationFactory notificationFactory)
      {
         throw new NotImplementedException();
      }

        public List<Notification> GetNotificationsByRecieverId(int recieverId)
        {
            throw new NotImplementedException();
        }

        public NotificationDoctorRepository notificationDoctorRepository;
   
   }
}