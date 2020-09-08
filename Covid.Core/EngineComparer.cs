using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;

namespace Covid
{
    public static class EngineComparer
    {
        public static void Compare(params IEngine[] engines)
        {
            if(engines == null)
            {
                throw new ArgumentNullException("engines");
            }
            if (engines.Length < 2 || engines.Length > 10)
            {
                throw new ArgumentException("Invalid number of engines; should be (2, 10)", "engines");
            }

            var testData = new CsvReader().ReadTestData();
            var stopwatches = engines.Select(x => new Stopwatch()).ToList();

            Console.WriteLine("=============================================================");

            foreach (var query in testData)
            {
                Console.WriteLine("Query: " + query);

                stopwatches.First().Start();
                var baseResult = engines.First().Match(query);
                stopwatches.First().Stop();

                Console.WriteLine("Match: " + JsonConvert.SerializeObject(baseResult));

                for (int i = 1; i < engines.Length; i++)
                {
                    stopwatches[i].Start();
                    var result = engines[i].Match(query);
                    stopwatches[i].Stop();

                    Debug.Assert(result.QuestionText == baseResult.QuestionText, 
                        $"Inconsistent match encountered for {engines[i].GetType()}: {JsonConvert.SerializeObject(baseResult)}");
                }

                Console.WriteLine("");
            }

            Console.WriteLine("=============================================================");

            for (int i = 0; i < engines.Length; i++)
            {
                if(i > 0)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                }
                Console.WriteLine("Engine name: " + engines[i].GetType());
                Console.WriteLine("Average running time (ms): " + (stopwatches[i].ElapsedMilliseconds / testData.Count));
            }
            
            Console.WriteLine("=============================================================");
            Console.WriteLine();
        }
    }
}
