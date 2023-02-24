using Model;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface INotification
   {
      void CreateNotification(NotificationFactory notificationFactory);
      
      List<Notification> GetNotificationsByRecieverId(int recieverId);
   
   }
}