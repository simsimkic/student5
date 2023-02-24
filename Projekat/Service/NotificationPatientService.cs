using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class NotificationPatientService : INotification
    {

        public void CreateNotification(NotificationFactory notificationFactory)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetNotificationsByRecieverId(int recieverId)
        {
            throw new NotImplementedException();
        }


        internal List<NotificationPatient> GetNotificationForPatient(Patient patient)
        {
            return notificationPatientRepository.GetNotificationForPatient(patient);
        }

        public NotificationPatientRepository notificationPatientRepository = new NotificationPatientRepository();
    }
}