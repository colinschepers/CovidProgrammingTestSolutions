namespace Covid.Console
{
    class Program
    {
        static void Main()
        {
            var data = new CsvReader().ReadCovidData();

            EngineComparer.Compare(new FastEngine(data), new MyEngine(data));

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
