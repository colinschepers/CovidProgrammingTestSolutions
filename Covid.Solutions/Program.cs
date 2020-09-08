using Covid.Core;
using System;

namespace Covid.Solutions
{
    class Program
    {
        static void Main()
        {
            var data = new CsvReader().ReadCovidData();

            EngineComparer.Compare(new Engine1(data), new Engine2(data), new Engine3(data), new Engine4(data), new Engine5(data));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
