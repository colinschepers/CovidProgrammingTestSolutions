using System.Collections.Generic;
using System.Linq;

namespace Covid.Core.Engines
{
    public class FastEngine : IEngine
    {
        private readonly Dictionary<DataEntry, HashSet<string>> _data;

        public FastEngine(List<DataEntry> data)
        {
            _data = data.ToDictionary(x => x, x => new HashSet<string>(Tokenizer.Tokenize(x.QuestionText)));
        }

        /// <summary>
        /// Returns the best matching DataEntry based on a query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The best DataEntry with the most matching words</returns>
        public DataEntry Match(string query)
        {
            DataEntry bestMatch = null;
            int bestScore = 0;

            var queryWords = Tokenizer.Tokenize(query);

            foreach (var kvp in _data)
            {
                var score = 0;
                var questionWords = kvp.Value;

                foreach (var queryWord in queryWords)
                {
                    if (questionWords.Contains(queryWord))
                    {
                        score++;
                    }
                }

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMatch = kvp.Key;
                }
            }

            return bestMatch;
        }
    }
}