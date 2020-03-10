using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapTaskInterfaces.Entities;
using MapTaskInterfaces.Interfaces;

namespace MapTask.Core.Implementations
{
    internal class NeighborSearch: INeighborSearchStrategy
    {
        public IEnumerable<City> Search(City city, IEnumerable<City> cities)
        {
            return cities.Where(n => SearchLogic(city.Coordinate, n.Coordinate));
        }

        private bool SearchLogic(Point first, Point second)
        {
            return (
                Point.Add(first, new Size(0, 1)) == second ||
                Point.Add(first, new Size(1, 0)) == second ||
                Point.Add(first, new Size(0, -1)) == second ||
                Point.Add(first, new Size(-1, 0)) == second
                );
        }
    }
}
