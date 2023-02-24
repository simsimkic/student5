using System;
using System.Collections.Generic;

namespace Model
{
    public  class User
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String PersonalNumber { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Boolean Active { get; set; }

        public Address Address { get; set; }
        public List<BugReport> BugReport { get; set; }

        public User()
        {

        }

        public User(string name, string surname, string personalNumber, string phoneNumber, string email, string password, bool active, Address address, List<BugReport> bugReport)
        {
            Name = name;
            Surname = surname;
            PersonalNumber = personalNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Active = active;
            Address = address;
            BugReport = bugReport;
        }

        public User(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            PersonalNumber = user.PersonalNumber;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            Password = user.Password;
            Active = user.Active;
            Address = user.Address;
            BugReport = user.BugReport;
        }
    }
}