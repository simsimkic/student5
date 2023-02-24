using System;

namespace Model
{
    public class City
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Name { get; set; }

        public City()
        {
        }

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public City(City city)
        {
            Id = city.Id;
            Name = city.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is City city &&
                   Id == city.Id;
        }
    }
}