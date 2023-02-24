using System;
using System.Collections.Generic;

namespace Model
{
   public class Therapy
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public Boolean Prescribed { get; set; }
        public List<Drug> Drugs { get; set; }
      
    
        public Therapy()
        {
            Drugs = new List<Drug>();
        }

        public Therapy(Boolean prescribed, List<Drug> drugs)
        {
            Prescribed = prescribed;
            Drugs = drugs;
        }
   
        public Therapy(Therapy therapy)
        {
            Id = therapy.Id;
            Prescribed = therapy.Prescribed;
            Drugs = therapy.Drugs;
        }

        public override bool Equals(object obj)
        {
            return obj is Therapy therapy &&
                   Id == therapy.Id;
        }
    }
}