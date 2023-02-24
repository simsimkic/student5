using System;

namespace Model
{
   public class Warden : User
   {
        public static int idGenerator = 0;
        public int Id { get; set; }

        public Warden() { }

        public Warden(int id)
        {
            Id = id;
        }

        public Warden(Warden warden)
        {
            Id = warden.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Warden warden &&
                   base.Equals(obj) &&
                   Id == warden.Id;
        }
    }
}