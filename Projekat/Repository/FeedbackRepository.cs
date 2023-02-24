using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class FeedbackRepository : GenericRepository<Feedback>
   {
      public List<Feedback> GetFeedbacksByDoctorId(int doctorId)
      {
         throw new NotImplementedException();
      }
   
   }
}