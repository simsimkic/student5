using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController
    {
        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        public Room StartRenovationRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        public String UpdateRoomType(Room room,  RoomType type)
        {
            try
            {
                roomService.UpdateRoomType(room,type);
                return "Room type changed successfuly!";
            }
            catch(RoomTypeException e)
            {
                return "Invalid room type!";
            }
        }

        public String RearangeInventory(Room room1, Room room2, int direction, List<InventoryItem> items)
        {
            try
            {
                roomService.RearangeInventory(room1, room2, direction, items);
                return "Items rearanged successfuly!";
            }
            catch(MaxInventoryItemsReachedException e)
            {
                return "Maximum room capacity reached!";
            }
            catch(MaxInventoryItemsInvalidException)
            {
                return "Invalid maximum room capacity entered!";
            }
        }

        public String CreateRoom(Room room)
        {
            try
            {
                roomService.CreateRoom(room);
                return "Room Successfuly created!";
            }
            catch(RoomSizeException e)
            {
                return "Room size must be between 0 and 500 m^2";
            }
            catch(RoomTypeException e)
            {
                return "Room type invalid";
            }

        }

        public String MergeRooms(List<Room> rooms)
        {
            try
            {
                roomService.MergeRooms(rooms);
                return "Room Successfuly merged!";
            }
            catch (RoomSizeException e)
            {
                return "Room size must be between 0 and 500 m^2";
            }
            catch (RoomTypeException e)
            {
                return "Room type invalid";
            }
        }

        public String DivideRoom(Room room, float roomSize)
        {
          
            roomService.DivideRoom(room,roomSize);
            return "Room Successfuly divided!";
        }

        public Room FinishRenovationRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoom(int roomId)
        {
            throw new NotImplementedException();
        }
        public List<InventoryItem> GetAllInventoryItems()
        {
            return roomService.GetAllInventoryItems();
        }
        public List<Room> GetRoomsByType(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public RoomService roomService = new RoomService();

    }
}