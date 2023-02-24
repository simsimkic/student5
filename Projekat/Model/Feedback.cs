using System;

namespace Model
{
    public class Feedback
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Comment { get; set; }
        public int Grade { get; set; }

        public Appointment Appointment { get; set; }

        public Feedback()
        {
        }

        public Feedback(int id, string comment, int grade, Appointment appointment)
        {
            Id = Id;
            Comment = comment;
            Grade = grade;
            Appointment = appointment;
        }
        public Feedback(Feedback feedback)
        {
            Id = feedback.Id;
            Comment = feedback.Comment;
            Grade = feedback.Grade;
            Appointment = feedback.Appointment;
        }

        public override bool Equals(object obj)
        {
            return obj is Feedback feedback &&
                   Id == feedback.Id;
        }
    }
}