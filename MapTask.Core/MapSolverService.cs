using MapTaskInterfaces.Entities;
using MapTaskInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTask.Core
{
    public class MapSolverService
    {
        private readonly IParser _parser;
        private readonly ISolver _solver;

        public MapSolverService(IParser parser, ISolver solver)
        {
            _parser = parser;
            _solver = solver;
        }

        public void Solve(string path)
        {
            var parsedData = _parser.FromFile(path);
            var processedData = _solver.Process(parsedData);
            _parser.ToFile(Path.GetFullPath(@"..\..\") + @"IOData\ResultData.txt", processedData.Cities);
        }
    }
}
