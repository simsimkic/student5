using Model;
using Repository;
using System;
using System.Collections.Generic;


namespace Service
{
    public class RoomService
    {
        public Boolean IsRoomAvailable(Room room, DateTime time, TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAvailableRooms()
        {
            throw new NotImplementedException();
        }

        public Boolean IsRoomSizeValid(Room room)
        {
            throw new NotImplementedException();
        }

        public Room UpdateRoomType(Room room, RoomType roomType)
        {
            room.Type = roomType;
            roomRepository.Update(room);
            return room;
        }

        public void FinishRearanging(Room room1, Room room2)
        {
            throw new NotImplementedException();
        }

        public Room CreateRoom(Room room)
        {
            ValidateRoomInfo(room);
            InitializeRoomFields(ref room);
            roomRepository.Create(room);
            return room;
        }

        private void InitializeRoomFields(ref Room room)
        {
            room.InventoryItems = new List<InventoryItem>();
            room.Appointments = new List<Appointment>();
            room.Patients = new List<Patient>();
            room.RoomRenovationArrangements = new List<RoomRenovationArrangement>();
         }

         public void ValidateRoomInfo(Room room)
        {
            if (UtilityService.isRoomSizeValid(room)) throw new RoomSizeException();
            if (UtilityService.isMaxInventoryItemsValid(room)) throw new MaxInventoryItemsInvalidException();
            if (UtilityService.isRoomTypeValid(room)) throw new RoomTypeException();
        }

        public Room MergeRooms(List<Room> rooms)
        {
            Room newRoom = CalculateNewRoomInfo(rooms);
            roomRepository.Update(newRoom);
            rooms.RemoveAt(0);
            DeleteRooms(rooms);
            return newRoom;
        }
        public Room CalculateNewRoomInfo(List<Room> rooms)
        {
            float roomsSize = 0;
            int roomsMaxCapacity = 0;
            List<InventoryItem> inventoryItems = new List<InventoryItem>();
            foreach (Room room in rooms)
            {
                roomsSize += room.Size;
                roomsMaxCapacity += room.MaxInventoryItems;
                inventoryItems.AddRange(GetAllInventoryItemsFromRoom(room));
            }
            rooms[0].InventoryItems = inventoryItems;
            rooms[0].Size = roomsSize;
            rooms[0].MaxInventoryItems = roomsMaxCapacity;
            return rooms[0];
        }
        public List<InventoryItem> GetAllInventoryItemsFromRoom(Room room)
        {
            List<InventoryItem> inventoryItems = new List<InventoryItem>();
            foreach (InventoryItem item in room.InventoryItems)
            {
                inventoryItems.Add(item);
            }
            return inventoryItems;
        }
        public void DeleteRooms(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                roomRepository.Delete(room.Id);
            }
        }

        public void DivideRoom(Room room, float roomSize)
        {
            Room newRoom = new Room(room);
            if (room.Size > roomSize)
            {
                newRoom.Size = roomSize;
                newRoom.MaxInventoryItems = (int)Math.Floor(roomSize / 2);
                room.MaxInventoryItems -= newRoom.MaxInventoryItems;
                room.Size -= roomSize;
            }
            roomRepository.Update(room);
            roomRepository.Create(newRoom);
        }

        public Boolean IsRenovationRoomSizeValid()
        {
            throw new NotImplementedException();
        }

        internal List<InventoryItem> GetAllInventoryItems()
        {
            throw new NotImplementedException();
        }

        public void RearangeInventory(Room room1, Room room2, int direction, List<InventoryItem> items)
        {
            if (direction == 1)
            {
                SwitchItems(ref room1, ref room2, items);
                //roomRepository.Update(room2);
            }
            else
            {
                SwitchItems(ref room2, ref room1, items);
                //roomRepository.Update(room2);
            }
        }

        private void SwitchItems(ref Room sourceRoom,ref Room targetRoom, List<InventoryItem> items)
        {
            List<InventoryItem> items_copy = new List<InventoryItem>(items);
            foreach (InventoryItem item in items_copy)
            {
                sourceRoom.InventoryItems.Remove(item);
                targetRoom.InventoryItems.Add(item);
            }
            roomRepository.Update(sourceRoom);
            roomRepository.Update(targetRoom);
            /*
            foreach (InventoryItem inventoryItem in items)
            {
                foreach (InventoryItem roomInventoryItem in sourceRoom.InventoryItems)
                {
                    if (InventoryItemService.IsSameInventoryItem(inventoryItem,roomInventoryItem))
                    {
                        sourceRoomCopy.InventoryItems.Remove(roomInventoryItem);
                        roomRepository.Update(sourceRoom);
                        AddInventoryItem(targetRoom, inventoryItem);
                    }
                }
            }*/
        }
        public void AddInventoryItem(Room target_room, InventoryItem inventoryItem)
        {
            if (target_room.InventoryItems.Count < target_room.MaxInventoryItems)
            {
                target_room.InventoryItems.Add(inventoryItem);
                roomRepository.Update(target_room);
            }
            else throw new MaxInventoryItemsReachedException();
        }
        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAllRooms();
        }
        public Room GetWarehouse()
        {
            return roomRepository.GetWarehouse();
        }
        public List<Room> GetRoomsByType(RoomType roomType)
        {
            throw new NotImplementedException();
        }
        public RoomRepository roomRepository = new RoomRepository();
        public InventoryItemService InventoryItemService = new InventoryItemService();
        public RoomRenovationArrangementService roomRenovationArrangementService;

    }
}