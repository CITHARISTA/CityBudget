using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTaskInterfaces.Entities
{
    public class InputData
    {
        public IEnumerable<City> Cities { get; private set; }
        public int Repeats { get; private set; }
        public float SpentPercent { get; private set; }

        public InputData(IEnumerable<City> cities, int repeats, float spent)
        {
            Cities = cities;
            Repeats = repeats;
            SpentPercent = spent;
        }
    }
}
