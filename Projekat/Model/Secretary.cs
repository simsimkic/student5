using System;
using System.Collections.Generic;

namespace Model
{
   public class Secretary : User
   {

        public static int idGenerator = 0;
        public int Id { get; set; }
        public WorkingTime WorkingTime { get; set; }
        public List<NotificationFactory> NotificationFactory { get; set; }
        

        public Secretary() { }
    
        public Secretary(int id, WorkingTime workingTime, List<NotificationFactory> notificationFactories,User user) : base(user)
        {
            Id = id;
            WorkingTime = workingTime;
            NotificationFactory = notificationFactories;
        }

        public Secretary(Secretary secretary)
        {
            Id = secretary.Id;
            WorkingTime = secretary.WorkingTime;
            NotificationFactory = secretary.NotificationFactory;
        }

        public override bool Equals(object obj)
        {
            return obj is Secretary secretary &&
                   base.Equals(obj) &&
                   Id == secretary.Id;
        }
    }
}