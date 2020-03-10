using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTaskInterfaces.Entities
{
    public class ProcessedData
    {
        public InputData InputData { get; private set; }
        public List<City> Cities { get; private set; }

        public ProcessedData(InputData inputData, List<City> cities)
        {
            InputData = inputData;
            Cities = cities;
        }
    }
}
