using MapTask.Core.Implementations;
using MapTaskInterfaces.Entities;
using MapTaskInterfaces.Interfaces;
using MapTestProject.Mocks;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapTestProject
{
    public class SolverTest
    {
        private readonly ISolver solver;
        private readonly IValidator validator;
        private readonly INeighborSearchStrategy neighbor;
        private readonly SolverMocks mocks;

        public SolverTest()
        {
            mocks = new SolverMocks();
            validator = new Validator();
            neighbor = new NeighborSearch();
            solver = new Solver(validator, neighbor);
        }



        [Test]
        public void WithEqualBudgetsAfterSolverBudgetDoesNotChange()
        {

            var exceptCities = mocks.CitiesWithTheSameBudget.Cities.ToList();
            var resultCities = solver.Process(mocks.CitiesWithTheSameBudget).Cities;

            for (int i = 0; i < exceptCities.Count(); i++)
            {
                Assert.AreEqual(exceptCities[i].Budget, resultCities[i].Budget);
            }
        }

        [Test]
        public void InputDataDontChangeAfterSolver()
        {
            var except = mocks.SimpleInputData;
            var result = solver.Process(mocks.SimpleInputData).InputData;

            Assert.AreEqual(JsonConvert.SerializeObject(except), JsonConvert.SerializeObject(result));
        }

        [Test]
        public void BudgetsAfterSolver()
        {
            var exceptCities = mocks.ResultOfSimpleInputDataAfterSolver.Cities.ToList();
            var resultCities = solver.Process(mocks.SimpleInputData).Cities;

            for (int i = 0; i < exceptCities.Count(); i++)
            {
                Assert.AreEqual(exceptCities[i].Budget, resultCities[i].Budget);
            }
        }
    }
}
