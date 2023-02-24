using System;

namespace Model
{
   public class NotificationPatient : Notification
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public DateTime CanceledAppointment { get; set; }
        public DateTime NewAppointment { get; set; }
        public Patient Patient { get; set; }

        public NotificationPatient() { }

        public NotificationPatient(int id,DateTime cancelAppointment, DateTime newAppointment, Patient patient)
        {
            Id = id;
            CanceledAppointment = cancelAppointment;
            NewAppointment = newAppointment;
            Patient = patient;
        }
   
        public NotificationPatient(NotificationPatient notificationPatient)
        {
            Id = notificationPatient.Id;
            CanceledAppointment = notificationPatient.CanceledAppointment;
            NewAppointment = notificationPatient.NewAppointment;
            Patient = notificationPatient.Patient;
        }

        public override bool Equals(object obj)
        {
            return obj is NotificationPatient patient &&
                   Id == patient.Id;
        }
    }
}