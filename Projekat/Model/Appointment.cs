using System;

namespace Model
{
    public class Appointment
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Duration { get; set; }
        public  Boolean Emergency { get; set; }
        public Boolean Operation { get; set; }
        public Boolean Completed { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public AppointmentReport AppointmentReport { get; set; }
        public Feedback Feedback { get; set; }
        public Doctor Doctor { get; set; }

        public Appointment()
        {
        }

        public Appointment(int id, DateTime time, TimeSpan duration, bool emergency, bool operation, bool completed, Patient patient, Room room, AppointmentReport appointmentReport, Feedback feedback)
        {
            Id = id;
            Time = time;
            Duration = duration;
            Emergency = emergency;
            Operation = operation;
            Completed = completed;
            Patient = patient;
            Room = room;
            this.AppointmentReport = appointmentReport;
            this.Feedback = feedback;
        }

        public Appointment(Appointment appointment)
        {
            Id = appointment.Id;
            Time = appointment.Time;
            Duration = appointment.Duration;
            Emergency = appointment.Emergency;
            Operation = appointment.Operation;
            Completed = appointment.Completed;
            Patient = appointment.Patient;
            Room = appointment.Room;
            this.AppointmentReport = appointment.AppointmentReport;
            this.Feedback = appointment.Feedback;
        }

        internal bool InRange(DateTime startingPoint, DateTime endingPoint)
        {
            return ((Time > startingPoint) && (Time < endingPoint));
        }

        public bool BelongsToPatient(Patient patient)
        {
            // zbog toga sto je u patient.txt id=0 a u appointment.txt id=1 
            return (patient.Id) == this.Patient.Id;
        }

        public bool IsInFuture()
        {
            return (this.Time > DateTime.Now);
        }

        public override bool Equals(object obj)
        {
            return obj is Appointment appointment &&
                   Id == appointment.Id;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}