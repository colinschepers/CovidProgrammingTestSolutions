using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Covid
{
    public class CsvReader
    {
        private static readonly string _csvPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "covid-data.csv");

        public List<DataEntry> Read()
        {
            var data = new List<DataEntry>(); 

            using (var csvReader = new StreamReader(_csvPath))
            {
                string line;
                while ((line = csvReader.ReadLine()) != null)
                {
                    data.Add(DataEntry.Parse(line));
                }
            }

            return data.ToList();
        }
    }
}
