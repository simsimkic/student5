using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomRenovationArrangementController
   {
      public List<RoomRenovationArrangement> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public List<RoomRenovationArrangement> GetRoomRenovationArrangementByRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
      public RoomRenovationArrangement CreateRenovationArrangement(RoomRenovationArrangement roomRenovation)
      {
         throw new NotImplementedException();
      }
      
      public List<RoomRenovationArrangementService> roomRenovationArrangementService;
      
      
      public List<RoomRenovationArrangementService> RoomRenovationArrangementService
      {
         get
         {
            if (roomRenovationArrangementService == null)
               roomRenovationArrangementService = new List<RoomRenovationArrangementService>();
            return roomRenovationArrangementService;
         }
         set
         {
            RemoveAllRoomRenovationArrangementService();
            if (value != null)
            {
               foreach (RoomRenovationArrangementService oRoomRenovationArrangementService in value)
                  AddRoomRenovationArrangementService(oRoomRenovationArrangementService);
            }
         }
      }
      
      public void AddRoomRenovationArrangementService(RoomRenovationArrangementService newRoomRenovationArrangementService)
      {
         if (newRoomRenovationArrangementService == null)
            return;
         if (this.roomRenovationArrangementService == null)
            this.roomRenovationArrangementService = new List<RoomRenovationArrangementService>();
         if (!this.roomRenovationArrangementService.Contains(newRoomRenovationArrangementService))
            this.roomRenovationArrangementService.Add(newRoomRenovationArrangementService);
      }
      
      public void RemoveRoomRenovationArrangementService(RoomRenovationArrangementService oldRoomRenovationArrangementService)
      {
         if (oldRoomRenovationArrangementService == null)
            return;
         if (this.roomRenovationArrangementService != null)
            if (this.roomRenovationArrangementService.Contains(oldRoomRenovationArrangementService))
               this.roomRenovationArrangementService.Remove(oldRoomRenovationArrangementService);
      }
      
      public void RemoveAllRoomRenovationArrangementService()
      {
         if (roomRenovationArrangementService != null)
            roomRenovationArrangementService.Clear();
      }
   
   }
}