using MapTaskInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace MapTestProject
{
    class ParserTest
    {
        public List<City> ParseWithoutRepeatsAndPercent(string path)
        {
            List<City> listOfCities = new List<City>();
            string[] arrayFromFile = File.ReadAllLines(path);
            for (int i = 0; i < arrayFromFile.Length; i++)
            {
                string[] splitLine = arrayFromFile[i].Split(' ');
                listOfCities.Add(new City(splitLine[3], Convert.ToDecimal(splitLine[2]),
                    new Point(Convert.ToInt32(splitLine[0]), Convert.ToInt32(splitLine[1]))));
            }

            return listOfCities;
        }
    }
}
