using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class TherapyRepository : GenericRepository<Therapy>
   {
      public List<Therapy> GetTherapiesByPatientId(int patientId)
      {
         throw new NotImplementedException();
      }
   
   }
}