using MapTask.Core;
using MapTask.Core.Implementations;
using MapTaskInterfaces.Interfaces;
using MapTestProject.Mocks;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Compatibility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace MapTestProject
{
    public class MapSolverServiceTest
    {
        private readonly MapSolverServiceMocks mocks;
        private readonly MapSolverService solverService;
        private readonly ParserTest parser;
        private readonly ISolver solver;

        public MapSolverServiceTest()
        {
            parser = new ParserTest();
            mocks = new MapSolverServiceMocks();

            solver = new Solver(new Validator(), new NeighborSearch());
            solverService = new MapSolverService(new SimpleParser(), solver);
        }

        [Test]
        public void CheckForExceptions()
        {
            mocks.FilePathsWithExceptions.ToLookup(x => Assert.Throws<Exception>(() => solverService.Solve(x)));
        }

        [Test]
        public void CorrectConclusion()
        {
            string pathOfInputFile = @"U:\www\SolverServiceTests\CorrectConclusion_input.txt";
            string pathOfOutputFile = @"U:\www\result.txt";

            solverService.Solve(pathOfInputFile);
            var result = parser.ParseWithoutRepeatsAndPercent(pathOfOutputFile);
            var expected = mocks.CorrectConclutionResult;

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }
}
