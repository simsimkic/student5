using System;
using System.Collections.Generic;

namespace Model
{
   public class WorkingTime
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public System.TimeSpan Start { get; set; }
        public System.TimeSpan Finish { get; set; }
        public List<Boolean> WorkingDays;

        public WorkingTime() { }

        public WorkingTime(int id, TimeSpan start, TimeSpan finish, List<Boolean> workingDays)
        {
            Id = id;
            Start = start;
            Finish = finish;
            WorkingDays = workingDays;
        }

        public WorkingTime(WorkingTime workingTime)
        {
            Id = workingTime.Id;
            Start = workingTime.Start;
            Finish = workingTime.Finish;
            WorkingDays = workingTime.WorkingDays;
        }

        public override bool Equals(object obj)
        {
            return obj is WorkingTime time &&
                   Id == time.Id;
        }
    }
}