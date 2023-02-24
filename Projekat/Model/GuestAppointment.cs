using System;

namespace Model
{
    public class GuestAppointment
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String AppointmentCode { get; set; }
        public System.DateTime Time { get; set; }
        public System.TimeSpan Duration { get; set; }
        public Boolean Emergency { get; set; }
        public Boolean Completed { get; set; }

        public Guest Guest { get; set; }
        public Doctor Doctor { get; set; }

        public GuestAppointment(int id, string appointmentCode, DateTime time, bool completed, Guest guest, Doctor doctor, TimeSpan duration, bool emergency = false)
        {
            Id = id;
            AppointmentCode = appointmentCode;
            Time = time;
            Duration = duration;
            Emergency = emergency;
            Completed = completed;
            Guest = guest;
            Doctor = doctor;
        }

        public GuestAppointment()
        {
        }

        public GuestAppointment(GuestAppointment guestAppointment)
        {
            Id = guestAppointment.Id;
            AppointmentCode = guestAppointment.AppointmentCode;
            Time = guestAppointment.Time;
            Duration = guestAppointment.Duration;
            Emergency = guestAppointment.Emergency;
            Completed = guestAppointment.Completed;
            Guest = guestAppointment.Guest;
            Doctor = guestAppointment.Doctor;
        }

        public override bool Equals(object obj)
        {
            return obj is GuestAppointment appointment &&
                   Id == appointment.Id;
        }

        public bool IsInFuture()
        {
            return (this.Time > DateTime.Now);
        }
    }
}