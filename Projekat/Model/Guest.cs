using System;

namespace Model
{
    public class Guest
    {
        public static int idGenerator = 0;
        public String Name { get; set; }
        public String Surname { get; set; }
        public String PersonalNumber { get; set; }
        public String PhoneNumber { get; set; }
        public int Id { get; set; }

        public GuestAppointment GuestAppointment { get; set; }

        public Guest()
        {
        }

        public Guest(int id, string name, string surname, string personalNumber, string phoneNumber, GuestAppointment guestAppointment)
        {
            Name = name;
            Surname = surname;
            PersonalNumber = personalNumber;
            PhoneNumber = phoneNumber;
            Id = id;
            GuestAppointment = guestAppointment;
        }
        public Guest(Guest guest)
        {
            Id = guest.Id;
            Name = guest.Name;
            Surname = guest.Surname;
            PersonalNumber = guest.PersonalNumber;
            PhoneNumber = guest.PhoneNumber;
            Id = guest.Id;
            GuestAppointment = guest.GuestAppointment;
        }

        public override bool Equals(object obj)
        {
            return obj is Guest guest &&
                   Id == guest.Id;
        }
    }
}