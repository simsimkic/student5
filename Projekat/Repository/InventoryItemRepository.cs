using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class InventoryItemRepository : GenericRepository<InventoryItem>
   {
      public List<InventoryItem> GetInventoryItemsByRoom(int roomId)
      {
         throw new NotImplementedException();
      }
   
   }
}