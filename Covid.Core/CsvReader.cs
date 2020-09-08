using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Covid.Core
{
    public class CsvReader
    {
        private static readonly string _covidDataPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Data", "covid-data.csv");
        private static readonly string _testDataPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Data", "test-data.csv");

        public List<DataEntry> ReadCovidData()
        {
            var data = new List<DataEntry>();

            using (var csvReader = new StreamReader(_covidDataPath))
            {
                string line;
                while ((line = csvReader.ReadLine()) != null)
                {
                    data.Add(DataEntry.Parse(line));
                }
            }

            return data.ToList();
        }

        public List<string> ReadTestData()
        {
            var data = new List<string>();

            using (var csvReader = new StreamReader(_testDataPath))
            {
                string line;
                while ((line = csvReader.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }

            return data.ToList();
        }
    }
}
