using System;
using System.Text;

namespace Model
{
   public class NotificationDoctor : Notification
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
    
        public NotificationDoctor() { }

        public NotificationDoctor(Appointment appointment)
        {
            Appointment = appointment;
        }

        public NotificationDoctor(NotificationDoctor notificationDoctor)
        {
            Appointment = notificationDoctor.Appointment;        }

        public override bool Equals(object obj)
        {
            return obj is NotificationDoctor doctor &&
                   Id == doctor.Id;
        }
    }
}