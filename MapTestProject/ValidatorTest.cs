using MapTask.Core.Implementations;
using MapTaskInterfaces.Entities;
using MapTestProject.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;

namespace MapTestProject
{
    public class ValidatorTest
    {
        private readonly ValidatorMocks mocks;
        private readonly Validator validator;

        public ValidatorTest()
        {
            mocks = new ValidatorMocks();
            validator = new Validator();
        }

        [Test]
        public void DoesTheCityHaveABudget()
        {
            var result = validator.IsValid(mocks.CityHaveANegativeBudget);
            Assert.IsFalse(result);
        }

        [Test]
        public void СitiesDoNotStandInOnePlace()
        {
            var result = validator.IsValid(mocks.СitiesStandInOnePlace);
            Assert.IsFalse(result);
        }

        [Test]
        public void AreAllCitiesAccessible()
        {
            var result = mocks.NotAllCitiesAccessible.Any(x => validator.IsValid(x));
            Assert.IsFalse(result);
        }
        
        [Test]
        public void NotNegativeCoordinates()
        {
            var listOfInputData = mocks.NegativeCoordinates.Select(x => new InputData(x, 150, 0.06f));
            var result = listOfInputData.Any(x => validator.IsValid(x));
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidPercent()
        {
            var cityMock = mocks.CorrectCity;
            var listOfInputData = mocks.ValidPercent.Select(x => new InputData(cityMock, 150, x));
            var result = listOfInputData.Any(x => validator.IsValid(x));
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidRepeats()
        {
            var cityMock = mocks.CorrectCity;
            var listOfInputData = mocks.ValidRepeats.Select(x => new InputData(cityMock, x, 0.06f));
            var result = listOfInputData.Any(x => validator.IsValid(x));
            Assert.IsFalse(result);
        }
    }

}
