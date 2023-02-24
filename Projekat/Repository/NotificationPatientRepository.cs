using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class NotificationPatientRepository : GenericRepository<NotificationPatient>
    {
        public List<NotificationPatient> GetNotificationPatientByPatientId(int patientId)
        {
            throw new NotImplementedException();
        }

        public List<NotificationPatient> GetNotificationForPatient(Patient patient)
        {
            List<NotificationPatient> notificationsForPatient = new List<NotificationPatient>();
            foreach (NotificationPatient notificaitonPatient in GetAll())
                if (notificaitonPatient.Patient.Id == patient.Id)
                    notificationsForPatient.Add(notificaitonPatient);

            return notificationsForPatient;
        }
    }
}