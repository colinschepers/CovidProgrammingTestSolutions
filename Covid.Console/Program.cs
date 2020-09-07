using System;
using System.Diagnostics;
using System.Linq;

namespace Covid
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
            var engine = new Engine(data);

            var stopwatch = Stopwatch.StartNew();
            var results = _queries.Select(q => new { Query = q, Match = engine.Match(q) }).ToList();
            stopwatch.Stop();

            for (int i = 0; i < _queries.Length; i++)
            {
                Debug.Assert(results[i].Match.QuestionText == _expected[i]);

                Console.WriteLine("Query: " + results[i].Query);
                Console.WriteLine("Question: " + results[i].Match.QuestionText);
                Console.WriteLine("Answer: "+ results[i].Match.AnswerText);
                Console.WriteLine();
            }

            Console.WriteLine("ElapsedMilliseconds: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
