using System;
using System.Collections.Generic;

namespace Model
{
   public class Room
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public float Size { get; set; }
        public int MaxInventoryItems { get; set; }
        public RoomType Type { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Patient> Patients { get; set; }
        public List<RoomRenovationArrangement> RoomRenovationArrangements { get; set; }
      
        public Room() { }
        
        public Room(int id, float size, RoomType type,int maxInventoryItems, List<InventoryItem> inventoryItems, List<Appointment> appointments, List<Patient> patients, List<RoomRenovationArrangement> roomRenovationArrangements)
        {
            Id = id;
            Size = size;
            Type = type;
            MaxInventoryItems = maxInventoryItems;
            InventoryItems = inventoryItems;
            Appointments = appointments;
            Patients = patients;
            RoomRenovationArrangements = roomRenovationArrangements;
        }
    

        public Room(Room room)
        {
            Id = room.Id;
            Size = room.Size;
            Type = room.Type;
            MaxInventoryItems = room.MaxInventoryItems;
            InventoryItems = room.InventoryItems;
            Appointments = room.Appointments;
            Patients = room.Patients;
            RoomRenovationArrangements = room.RoomRenovationArrangements;
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   Id == room.Id;
        }
    }
}