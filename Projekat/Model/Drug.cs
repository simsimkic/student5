using System;
using System.Collections.Generic;

namespace Model
{
    public class Drug
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String DrugInformation { get; set; }
        public Boolean Approved { get; set; }
        public List<String> Purpose { get; set; }
        public Boolean FromPharmacy { get; set; }
        public Therapy[] Therapy { get; set; }

        public Drug()
        {
        }

        public Drug(int id, string name, int quantity, string drugInformation, List<string> purpose, Therapy[] therapy, bool approved = false, bool fromPharmacy = true)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            DrugInformation = drugInformation;
            Approved = approved;
            Purpose = purpose;
            FromPharmacy = fromPharmacy;
            Therapy = therapy;
        }

        public Drug(Drug drug)
        {
            Id = drug.Id;
            Name = drug.Name;
            Quantity = drug.Quantity;
            DrugInformation = drug.DrugInformation;
            Approved = drug.Approved;
            Purpose = drug.Purpose;
            FromPharmacy = drug.FromPharmacy;
            Therapy = drug.Therapy;
        }

        public override bool Equals(object obj)
        {
            return obj is Drug drug &&
                   Id == drug.Id;
        }
    }
}