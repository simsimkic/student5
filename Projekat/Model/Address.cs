using System;
using System.Runtime.Serialization;

namespace Model
{
    public class Address
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String StreetName { get; set; }
        public String HouseNumber { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }

        public Address()
        {
        }

        public Address(int id, string streetName, string houseNumber, Country country, City city)
        {
            Id = id;
            StreetName = streetName;
            HouseNumber = houseNumber;
            Country = country;
            City = city;
        }

        public Address(Address address)
        {
            Id = address.Id;
            StreetName = address.StreetName;
            HouseNumber = address.HouseNumber;
            Country = address.Country;
            City = address.City;
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Id == address.Id;
        }
    }
}