using System.Collections.Generic;

namespace Covid.Core.Engines
{
    public class SlowEngine : IEngine
    {
        private readonly List<DataEntry> _data;

        public SlowEngine(List<DataEntry> data)
        {
            _data = data;
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

            foreach (var item in _data)
            {
                var score = 0;
                var questionWords = Tokenizer.Tokenize(item.QuestionText);

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
                    bestMatch = item;
                }
            }

            return bestMatch;
        }
    }
}