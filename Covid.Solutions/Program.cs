using System;
using System.Diagnostics;
using System.Linq;

namespace Covid.Solutions
{
    class Program
    {
        private static readonly string[] _queries = new string[]
        {
            "What is R0 of COVID estimated ?",
            "when was SARS exactly identified",
            "i would like to know the incubation time for COVID19",
            "Covid. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque volutpat nec enim ac euismod. Donec eu feugiat felis. Nunc sed dui vitae dolor convallis malesuada."
        };

        private static readonly string[] _expected = new string[]
        {
            "What is the estimated R0 of COVID-19?",
            "When was SARS-CoV-2 first identified?",
            "How long is the incubation time for COVID19?",
            "How many states in the U.S. have reported cases of COVID-19?"
        };

        static void Main()
        {
            var data = new CsvReader().Read();
            var engines = new IEngine[] { new Engine1(data), new Engine2(data), new Engine3(data), new Engine4(data), new Engine5(data) };
            var stopwatch = new Stopwatch();

            foreach (var engine in engines)
            {
                stopwatch.Restart();
                var matches = _queries.Select(q => engine.Match(q)).ToList();
                stopwatch.Stop();

                for (int i = 0; i < _queries.Length; i++)
                {
                    Debug.Assert(matches[i].QuestionText == _expected[i]);
                }

                Console.WriteLine($"{engine.GetType().Name} ElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
