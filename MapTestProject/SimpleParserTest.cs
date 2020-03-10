using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MapTask.Core.Implementations;
using MapTaskInterfaces.Entities;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.Drawing;
using MapTestProject.Mocks;

namespace MapTestProject
{

    public class SimpleParserTest
    {
        private readonly ParserTest parserTest;
        private readonly SimpleParser simpleParser;
        private readonly ParserMocks mocks;

        public SimpleParserTest()
        {
            parserTest = new ParserTest();
            mocks = new ParserMocks();
            simpleParser = new SimpleParser();
        }

        [Test]
        public void ParseDataFromFile()
        {
            string path = @"U:\www\SourceMapData_Test.txt";
            InputData expect = mocks.InputDataFromFile;
            InputData result = simpleParser.FromFile(path);
            Assert.AreEqual(JsonConvert.SerializeObject(expect), JsonConvert.SerializeObject(result));
        }

        [Test]
        public void WriteCitiesToFile()
        {
            string path = @"U:\www\result_test.txt";
            simpleParser.ToFile(path,mocks.ResultOfWrithToFile.Cities.ToList());
            List<City> expect = mocks.ResultOfWrithToFile.Cities.ToList();
            List<City> result = parserTest.ParseWithoutRepeatsAndPercent(path);
            Assert.AreEqual(JsonConvert.SerializeObject(expect), JsonConvert.SerializeObject(result));

        }
    }
}