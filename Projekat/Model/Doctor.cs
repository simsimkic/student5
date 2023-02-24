using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    public class Doctor : User
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public Boolean Specialist { get; set; }
        public WorkingTime WorkingTime { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Doctor doctor &&
                   base.Equals(obj) &&
                   Id == doctor.Id;
        }

        public Doctor()
        {
        }

        public Doctor(int id, bool specialist, WorkingTime workingTime, User user) : base(user)
        {
            Id = id;
            Specialist = specialist;
            WorkingTime = workingTime;
        }
        public Doctor(Doctor doctor) 
        {
            Id = doctor.Id;
            Name = doctor.Name;
            Surname = doctor.Surname;
            PersonalNumber = doctor.PersonalNumber;
            PhoneNumber = doctor.PhoneNumber;
            Email = doctor.Email;
            Password = doctor.Password;
            Active = doctor.Active;
            Address = doctor.Address;
            BugReport = doctor.BugReport;
            Specialist = doctor.Specialist;
            WorkingTime = doctor.WorkingTime;
        }
    }
}