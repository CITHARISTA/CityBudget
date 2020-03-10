using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;


namespace MapTaskInterfaces.Entities
{
    public class City
    {
        /*private int _name;
        private const int MAX_CITY_NAME_LENGTH = 50;*/

        public string Name { get; private set; }
        public decimal Budget { get; private set; }
        public Point Coordinate { get; private set; }

        public void Transfer(decimal amount)
        {
            Budget += amount;
        }

        public City(string pname, decimal budget, Point coordinate)
        {
            Name = pname;
            Budget = budget;
            Coordinate = coordinate;
        }

        public City Clone()
        {
            return new City(Name, Budget, Coordinate);
        }
    }
}