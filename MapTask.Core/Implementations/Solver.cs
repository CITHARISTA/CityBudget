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
    internal class Solver : ISolver
    {

        IValidator validator;
        INeighborSearchStrategy strategy;
        public Solver(IValidator _validator, INeighborSearchStrategy _nsStrategy)
        {
            validator = _validator;
            strategy = _nsStrategy;
        }

        public ProcessedData Process(InputData data)
        {
            if (!validator.IsValid(data))
                throw new Exception("Map is not valid!");

            var cities = SolverProcess(data);

            return new ProcessedData(data, cities);
        }

        private List<City> CreateNewCities(IEnumerable<City> oldCities)
        {
            return oldCities.Select(item => item.Clone()).ToList();
        }

        private List<decimal> HowMuchToPayNeighbors(List<City> cities, InputData data)
        {
            List<decimal> percentageOfBudget = new List<decimal>();
            foreach (var city in cities)
            {
                int countOfNeighbor = strategy.Search(city, cities).Count();
                decimal howMachToGive = Convert.ToDecimal(data.SpentPercent) * city.Budget;
                percentageOfBudget.Add(howMachToGive);
            }

            return percentageOfBudget;
        }

        private void BudgetAllocationByNeighbors(List<City> cities, List<decimal> percentageOfBudget)
        {
            int j = 0;
            foreach (var city in cities)
            {
                var neighbors = strategy.Search(city, cities);
                foreach (var neighbor in neighbors)
                {
                    neighbor.Transfer(percentageOfBudget[j]);
                }
                j++;
            }
        }

        private void SubtractTheAmountForNeighborsFromCities(List<City> cities, List<decimal> howMuchToPayNeighbors)
        {
            for (int i = 0; i < cities.Count(); i++)
            {
                int countOfNeighbor = strategy.Search(cities[i], cities).Count();
                cities[i].Transfer(-howMuchToPayNeighbors[i] * countOfNeighbor);
            }
        }

        private List<City> SolverProcess(InputData data)
        {
            List<City> cities = CreateNewCities(data.Cities);
            for (int i = 0; i < data.Repeats; i++)
            {
                var howMuchToPayNeighbors = HowMuchToPayNeighbors(cities, data);
                SubtractTheAmountForNeighborsFromCities(cities, howMuchToPayNeighbors);
                BudgetAllocationByNeighbors(cities, howMuchToPayNeighbors);
            }

            return cities;
        }
    }
}
