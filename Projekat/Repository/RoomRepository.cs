using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class RoomRepository : GenericRepository<Room>
    {
        public List<Room> GetRoomsByRoomType(RoomType roomType)
        {
            List<Room> allRooms = GetAllRooms();
            List<Room> roomsOfType = new List<Room>();
            foreach(Room room in allRooms)
            {
                if (room.Type == roomType) roomsOfType.Add(room);
            }
            return roomsOfType;
        }
        public List<Room> GetAllRooms()
        {
            return GetAll();
        }

        internal Room GetWarehouse()
        {
            List<Room> warehouses = GetRoomsByRoomType(RoomType.warehouse);
            return warehouses[0];
        }
    }
}