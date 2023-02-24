using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class NotificationPatientController
    {
        public void SendNotification(int notificationFactory)
        {
            throw new NotImplementedException();
        }

        public List<NotificationPatient> GetNotificationForPatient(Patient patient)
        {
            try
            {
                UtilityService.CheckUserForNull(patient);
                return notificationPatientService.GetNotificationForPatient(patient);
            } catch (InvalidUserException e)
            {
                throw new InvalidUserException();
            }
            
        }

        NotificationPatientService notificationPatientService = new NotificationPatientService();
    }
}