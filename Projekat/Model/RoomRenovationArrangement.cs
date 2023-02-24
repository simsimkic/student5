using System;
using System.Runtime.InteropServices;

namespace Model
{
   public class RoomRenovationArrangement
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Duration { get; set; }
        public RenovationType RenovationType { get; set; }
        
        public Room room { get; set; }
      
        public RoomRenovationArrangement() { }

        public RoomRenovationArrangement(int id, DateTime dateTime, TimeSpan timeSpan, RenovationType renovationType)
        {
            Id = id;
            Time = dateTime;
            Duration = timeSpan;
            RenovationType = renovationType;
        }

        public RoomRenovationArrangement(RoomRenovationArrangement roomRenovationArrangement)
        {
            Id = roomRenovationArrangement.Id;
            Time = roomRenovationArrangement.Time;
            Duration = roomRenovationArrangement.Duration;
            RenovationType = roomRenovationArrangement.RenovationType;
        }

        public override bool Equals(object obj)
        {
            return obj is RoomRenovationArrangement arrangement &&
                   Id == arrangement.Id;
        }
    }
}