using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapTestProject.Mocks
{
    public class ValidatorMocks
    {
        public List<City> CorrectCity
        {
            get
            {
                return new List<City>
                {
                    new City("moscow", 1000000, new Point(1, 1)),
                    new City("moscow", 1000000, new Point(1, 2))
                };
            }
        }

        public List<List<City>> NegativeCoordinates
        {
            get
            {
                return new List<List<City>>
                {
                    new List<City>
                    {
                        new City("moscow", 1000000, new Point(-1, 0)),
                        new City("newyork", 100000, new Point(0, 0))
                    },
                    new List<City>
                    {
                        new City("moscow", 1000000, new Point(0, -1)),
                        new City("newyork", 100000, new Point(0, 0))
                    },
                    new List<City>
                    {
                        new City("moscow", 1000000, new Point(0, 0)),
                        new City("newyork", 100000, new Point(-1, 0))
                    },
                    new List<City>
                    {
                        new City("moscow", 1000000, new Point(0, 0)),
                        new City("newyork", 100000, new Point(0, -1))
                    }
                };
            }
        }

        public List<float> ValidPercent
        {
            get
            {
                return new List<float>
                {
                    1.1f,
                    -0.1f
                };
            }
        }

        public List<int> ValidRepeats
        {
            get
            {
                return new List<int>
                {
                    -10,
                    -1000
                };
            }
        }

        public List<InputData> NotAllCitiesAccessible
        {
            get
            {
                return new List<InputData>
                {
                    new InputData(
                        new List<City>
                        {
                            new City("tombov", 4800, new Point(1, 1)),
                            new City("test", 500, new Point(1, 2)),
                            new City("ugr", 3500, new Point(2, 3)),
                            new City("moscow", 4800, new Point(2, 4)),
                        },
                        150,
                        Convert.ToSingle(1.06)),
                    new InputData(
                        new List<City>
                        {
                            new City("tombov", 4800, new Point(1, 1)),
                            new City("test", 500, new Point(2, 2)),
                            new City("ugr", 3500, new Point(2, 1)),
                            new City("moscow", 4800, new Point(1, 2)),
                            new City("newyork1", 2500, new Point(7, 7)),
                            new City("newyork2", 2500, new Point(6, 6)),
                            new City("newyork3", 2500, new Point(6, 7)),
                            new City("newyork4", 2500, new Point(7, 6)),
                        },
                        150,
                        Convert.ToSingle(1.06)),
                };
            }
        }

        public InputData СitiesStandInOnePlace
        {
            get
            {
                return new InputData(
                    new List<City>
                    {
                        new City("tombov", 4800, new Point(1, 2)),
                        new City("test", 500, new Point(2, 1)),
                        new City("ugr", 3500, new Point(2, 2)),
                        new City("moscow", 4800, new Point(2, 3)),
                        new City("newyork", 2500, new Point(2, 3))
                    },
                    150,
                    Convert.ToSingle(1.06));
            }
        }

        public InputData CityHaveANegativeBudget
        {
            get
            {
                return new InputData(
                    new List<City>
                    {
                        new City("moscow", -500, new Point(1, 1)),
                        new City("newyork", 0, new Point(1, 2))
                    },
                    150,
                    Convert.ToSingle(1.06));
            }
        }
        

    }
}
