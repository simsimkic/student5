using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class PatientRepository : GenericRepository<Patient>
   {
      public List<Patient> GetPatientsByRoomId(int roomId)
      {
         throw new NotImplementedException();
      }
      
      public Patient GetPatientByPersonalNumber(String personalNumber)
      {
         throw new NotImplementedException();
      }
      
      public Patient GetPatientByName(String name)
      {
         throw new NotImplementedException();
      }

        public Patient GetByEmailAndPassword(string email, string password)
        {
            Patient patientFound = null;
            foreach(Patient patient in GetAll())
                if (patient.Email.Equals(email) & patient.Password.Equals(password))
                    patientFound = patient;
            return patientFound;
        }
    }
}