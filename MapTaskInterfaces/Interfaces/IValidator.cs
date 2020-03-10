using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTaskInterfaces.Interfaces
{
    public interface IValidator
    {
        bool IsValid(InputData data);
    }
}
