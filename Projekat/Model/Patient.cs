using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Model
{
   public class Patient : User
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public Boolean Hospitalized { get; set; }
       // public List<Appointment> Appointments { get; set; }
        public PatientFile PatientFile { get; set; }
        public Room SickRoom { get; set; }

        public Patient() { }

        public Patient(int id, Boolean hospitalized, List<Appointment> appointments, PatientFile patientFile, Room room, User user)
            : base(user)
        {
            Id = id;
            Hospitalized = hospitalized;
           // Appointments = appointments;
            PatientFile = patientFile;
            SickRoom = room;
        }
    
        public Patient(Patient patient)
        {
            Id = patient.Id;
            Hospitalized = patient.Hospitalized;
            ///Appointments = patient.Appointments;
            PatientFile = patient.PatientFile;
            SickRoom = patient.SickRoom;
            Name = patient.Name;
            Surname = patient.Surname;
            PersonalNumber = patient.PersonalNumber;
            PhoneNumber = patient.PhoneNumber;
            Email = patient.Email;
            Password = patient.Password;
            Active = patient.Active;
            Address = patient.Address;
            BugReport = patient.BugReport;
        }

        public override bool Equals(object obj)
        {
            return obj is Patient patient &&
                   base.Equals(obj) &&
                   Id == patient.Id;
        }
    }
}