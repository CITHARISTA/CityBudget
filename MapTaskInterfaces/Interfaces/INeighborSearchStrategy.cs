using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTaskInterfaces.Interfaces
{
    public interface INeighborSearchStrategy
    {
        IEnumerable<City> Search(City city, IEnumerable<City> cities);
    }
}
