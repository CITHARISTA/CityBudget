using MapTaskInterfaces.Entities;
using MapTaskInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTask.Core.Implementations
{
    internal class Validator: IValidator
    {
        public bool IsValid(InputData data)
        {
            bool isValid = NotNegativeBudget(data.Cities);
            isValid = isValid && СitiesDoNotStandInOnePlace(data.Cities);
            isValid = isValid && AreAllCitiesAccessible(data.Cities);
            isValid = isValid && NotNagativeRepeats(data.Repeats);
            isValid = isValid && ValidPercent(data.SpentPercent);
            isValid = isValid && NotNegativeCoordinates(data.Cities);

            return isValid;
        }

        private bool NotNegativeCoordinates(IEnumerable<City> cities)
        {
            return !cities.Any(city => city.Coordinate.X < 0 || city.Coordinate.Y < 0);
        }

        private bool ValidPercent(float percent)
        {
            return percent > 0 && percent < 1;
        }

        private bool NotNagativeRepeats(int repeats)
        {
            return repeats >= 0;
        }

        private bool СitiesDoNotStandInOnePlace(IEnumerable<City> cities)
        {
            return cities.All(item => cities.Count(city => item.Coordinate == city.Coordinate) == 1);
        }

        private bool NotNegativeBudget(IEnumerable<City> cities)
        {
            return cities.Count(b => b.Budget < 0) == 0;
        }

        private IEnumerable<Point> FindNeighbors(IEnumerable<City> cities, Point cityLocation)
        {
            return cities
                .Where(potentialNeighbour => IsNegihbors(potentialNeighbour.Coordinate, cityLocation))
                .Select(item => item.Coordinate);
        }

        private bool IsNegihbors(Point first, Point second)
        {
            return (
                Point.Add(first, new Size(0, 1)) == second ||
                Point.Add(first, new Size(1, 0)) == second ||
                Point.Add(first, new Size(0, -1)) == second ||
                Point.Add(first, new Size(-1, 0)) == second
                );
        }

        private bool AreAllCitiesAccessible(IEnumerable<City> cities)
        {
            List<Point> way = new List<Point>() { cities.First().Coordinate };
            for ( int i = 0; i < way.Count(); i++)
            {
                way = way.Union(FindNeighbors(cities, way[i])).ToList();
            }

            return way.Count() == cities.Count();
        }
    }
}
