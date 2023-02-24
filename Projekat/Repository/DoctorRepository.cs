using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class DoctorRepository : GenericRepository<Doctor>
   {
      public List<Doctor> GetAvailableDoctors(DateTime time)
      {
         throw new NotImplementedException();
      }
      
      public List<Doctor> GetDoctorsByWorkingTime(WorkingTime workingTime)
      {
            List<Doctor> allDoctors = GetDoctorsWithActiveAccounts();
            List<Doctor> doctors = new List<Doctor>();
           
            for(int i = 0; i < workingTime.WorkingDays.Count; i++)
                if(workingTime.WorkingDays[i])
                    foreach(Doctor doctor in allDoctors)
                        if (doctor.WorkingTime.WorkingDays[i] & workingTime.Start >= doctor.WorkingTime.Start & workingTime.Finish <= doctor.WorkingTime.Finish)
                            doctors.Add(doctor);

            return doctors;
      }

        public List<Doctor> GetDoctorsWithActiveAccounts()
        {
            List<Doctor> doctors = GetAll();
            List<Doctor> doctorsWithActiveAccount = new List<Doctor>();
            foreach (Doctor doctor in doctors)
                if (doctor.Active)
                    doctorsWithActiveAccount.Add(doctor);
            return doctorsWithActiveAccount;
        }
      

        internal Doctor GetByEmailAndPassword(string email, string password)
        {
            Doctor doctorFound = null;
            foreach (Doctor doctor in GetAll())
                if (doctor.Email.Equals(email) & doctor.Password.Equals(password))
                    doctorFound = doctor;
            return doctorFound;
        }

        public List<Doctor> GetDoctorsBySpecialist(Boolean specialist)

      {
         throw new NotImplementedException();
      }
   
   }
}