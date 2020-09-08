using Covid.Core;
using System.Collections.Generic;

namespace Covid.Console
{
    /// <summary>
    /// A slow engine. Can you optimize the matching logic?
    /// </summary>
    public class MyEngine : IEngine
    {
        private readonly List<DataEntry> _data;

        public MyEngine(List<DataEntry> data)
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

            foreach (var item in _data)
            {
                var score = 0;
                var queryWords = Tokenizer.Tokenize(query);
                var questionWords = Tokenizer.Tokenize(item.QuestionText);

                foreach (var queryWord in queryWords)
                {
                    foreach (var questionWord in questionWords)
                    {
                        if(queryWord == questionWord)
                        {
                            score++;
                        }
                    }
                }

                if(score > bestScore)
                {
                    bestScore = score;
                    bestMatch = item;
                }
            }

            return bestMatch;
        }
    }
}