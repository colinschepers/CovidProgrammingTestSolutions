using Covid.Core;
using Covid.Core.Engines;

namespace Covid.Console
{
    class Program
    {
        static void Main()
        {
            var data = new CsvReader().ReadCovidData();

            EngineComparer.Compare(new SuperEngine(data), new FastEngine(data), new SlowEngine(data), new MyEngine(data));

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
