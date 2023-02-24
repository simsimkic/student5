using System;
using System.Collections.Generic;

namespace Model
{
    public class Country
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Name { get; set; }
        public List<City> Cities { get; set; }

        public Country()
        {
        }

        public Country(int id, string name, List<City> cities)
        {
            Id = id;
            Name = name;
            Cities = cities;
        }

        public Country(Country country)
        {
            Id = country.Id;
            Name = country.Name;
            Cities = country.Cities;
        }

        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   Id == country.Id;
        }
    }
}