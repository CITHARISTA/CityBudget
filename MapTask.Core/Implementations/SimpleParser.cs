using MapTaskInterfaces.Entities;
using MapTaskInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Linq;

[assembly: InternalsVisibleToAttribute("MapTestProject")]
[assembly: InternalsVisibleToAttribute("MapTask")]
namespace MapTask.Core.Implementations
{
    internal class SimpleParser  : IParser
    {
        public InputData FromFile(string path)
        {
            var file = FileExists(path);
            var citiesAndPercentWithRepeats = ProcessFile(file);
            ProcessingExceptions(citiesAndPercentWithRepeats);

            return DataAssembly(citiesAndPercentWithRepeats);
        }

        public void ToFile(string path, List<City> cities)
        {
            StreamWriter file = new StreamWriter(path, false);
            
            foreach (var city in cities)
            {
                file.WriteLine(AssemblyStringFromCity(city));
            }

            file.Close();
        }

        private string AssemblyStringFromCity(City city)
        {
            return $"{city.Coordinate.X} {city.Coordinate.Y}" +
                    $" {(city.Budget == (int)city.Budget ? (int)city.Budget : city.Budget)}" +
                    $" {city.Name}";
        }

        private void ProcessingExceptions((List<City>, List<string>) data)
        {
            var notCity = data.Item2;
            var listOfCities = data.Item1;

            if (notCity.Count == 0 && listOfCities.Count == 0)
            {
                throw new Exception("File is empty");
            }
            else if (listOfCities.Count == 0)
            {
                throw new Exception("No cities data found");    
            }
            else if (notCity.Count == 0)
            {
                throw new Exception("Data of percent and repeats not found");
            }

            if (notCity.Count != 2)
            {
                throw new Exception("Data from file is not valid");
            }

            if (!Single.TryParse(notCity[1], out var percent))
                throw new Exception("The percent is not valid");

            if (!Int32.TryParse(notCity[0], out var repeats))
                throw new Exception("The repeats is not valid");
        }

        private StreamReader FileExists(string path)
        {
            try
            {
                return new StreamReader(path);
            }
            catch
            {
                throw new Exception("File not found");
            }
        }

        private (List<City>, List<string>) ProcessFile(StreamReader file)
        {
            List<City> listOfCities = new List<City>();
            List<string> notCity = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] dataOfLine = line.Split(' ');
                if (dataOfLine.Length == 4)
                {
                    listOfCities.Add(CreateCity(dataOfLine));
                }
                else
                {
                    notCity.Add(line);
                }
            }
            file.Close();

            return (listOfCities, notCity);
        }

        private City CreateCity(string[] dataOfLine)
        {
            Point point = new Point(Convert.ToInt32(dataOfLine[0]), Convert.ToInt32(dataOfLine[1]));

            return new City(dataOfLine[3], Convert.ToDecimal(dataOfLine[2]), point);
        }

        private InputData DataAssembly((List<City>, List<string>) data)
        {
            int repeats = Convert.ToInt32(data.Item2[0]);
            float percent = Convert.ToSingle(data.Item2[1]);

            return new InputData(data.Item1, repeats, percent);
        }
    }
}