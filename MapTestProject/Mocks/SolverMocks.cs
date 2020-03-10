using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapTestProject.Mocks
{
    public class SolverMocks
    {
        public InputData CitiesWithTheSameBudget
        {
            get
            {
                return new InputData(
                    new List<City>
                    {
                        new City("tombov", 10000, new Point(1, 1)),
                        new City("test", 10000, new Point(2, 2)),
                        new City("ugr", 10000, new Point(2, 1)),
                        new City("moscow", 10000, new Point(1, 2)),

                    },
                    150,
                    Convert.ToSingle(0.06));
            }
        }

        public InputData SimpleInputData
        {
            get
            {
                return new InputData(
                    new List<City>
                    {
                        new City("tombov", 1000000, new System.Drawing.Point(1, 1)),
                        new City("test", 100000, new System.Drawing.Point(2, 1)),
                    },
                    4,
                    Convert.ToSingle(0.1));
            }
        }

        public InputData ResultOfSimpleInputDataAfterSolver
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
