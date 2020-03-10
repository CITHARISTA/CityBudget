using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapTestProject.Mocks
{
    public class ParserMocks
    {
        public InputData InputDataFromFile
        {
            get
            {
                return new InputData(
                    new List<City>
                    {
                        new City("moscow", 1000000, new System.Drawing.Point(1, 1)),
                        new City("newyork", 100000, new System.Drawing.Point(1, 2))
                    },
                    4,
                    Convert.ToSingle(0.1));
            }
        }

        public InputData ResultOfWrithToFile
        {
            get
            {
                return new InputData(
                    new List<City>
                    {
                        new City("tombov", 734320, new System.Drawing.Point(1, 1)),
                        new City("test", 365680, new System.Drawing.Point(2, 1)),
                    },
                    4,
                    Convert.ToSingle(0.1));
            }
        }

    }
}
