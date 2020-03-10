using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTaskInterfaces.Interfaces
{
    public interface IParser
    {
        InputData FromFile(string path);

        void ToFile(string path, List<City> cities);
    }
}
