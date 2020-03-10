using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapTestProject.Mocks
{
    public class MapSolverServiceMocks
    {
        public IEnumerable<string> FilePathsWithExceptions
        {
            get
            {
                return new List<string>
                {  
                    @"U:\www\TestsExceptions\Empty.txt",
                    @"U:\www\TestsExceptions\NegativeBudget.txt",
                    @"U:\www\TestsExceptions\NegativeCoordinate.txt",
                    @"U:\www\TestsExceptions\NegativeRepeats.txt",
                    @"U:\www\TestsExceptions\NegativePercent.txt",
                    @"U:\www\TestsExceptions\WithoutBudget.txt",
                    @"U:\www\TestsExceptions\WithoutCities.txt",
                    @"U:\www\TestsExceptions\WithoutCoordinates.txt",
                    @"U:\www\TestsExceptions\WithoutCoordinateX.txt",
                    @"U:\www\TestsExceptions\WithoutCoordinateY.txt",
                    @"U:\www\TestsExceptions\WithoutName.txt",
                    @"U:\www\TestsExceptions\WithoutPercent.txt",
                    @"U:\www\TestsExceptions\WithoutRepeats.txt",
                    @"U:\www\TestsExceptions\WithTrash.txt",
                    @"U:\www\TestsExceptions\NotValidPercent.txt",
                    @"U:\www\TestsExceptions\NotValidRepeats.txt",
                    @"U:\www\TestsExceptions\NotFound.txt"
                };
            }
        }

        public List<City> CorrectConclutionResult
        {
            get
            {
                return new List<City>
                    {
                        new City("moscow", 734320, new System.Drawing.Point(1, 1)),
                        new City("newyork", 365680, new System.Drawing.Point(1, 2)),
                    };
            }
        }
    }
}
