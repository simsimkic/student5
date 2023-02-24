using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class DrugRepository : GenericRepository<Drug>
   {
      public List<Drug> GetDrugsByPurpose(String purpose)
      {
         throw new NotImplementedException();
      }
   
   }
}