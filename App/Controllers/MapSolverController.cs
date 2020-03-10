using MapTask.Core;
using MapTaskInterfaces.Interfaces;
using MapTask.Core.Implementations;

using System.Web.Http;
using System.IO;

namespace MapTask.Controllers
{
    [RoutePrefix("api/mapsolver")]
    public class MapSolverController: ApiController
    {
        private readonly Solver solver;
        private readonly MapSolverService mapSolver;

        public MapSolverController()
        {
            solver = new Solver(new Validator(), new NeighborSearch());
            mapSolver = new MapSolverService(new SimpleParser(), solver);
        }

        [HttpGet]
        public void Method()
        {
            string path = Path.GetFullPath(@"..\..\") + @"IOData\InputMapData.txt";
            mapSolver.Solve(path);
        }
    }
}
