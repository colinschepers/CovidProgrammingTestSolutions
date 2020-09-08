using Covid.Core;
using System.Collections.Generic;

namespace Covid.Solutions
{
    /// <summary>
    /// Second slowest version of the engine, improvement is to move the costly query string tokenization 
    /// out of the loop so that it is done only once.
    /// 
    /// The running time is O(nmqm) = O(n * q * m^2), 
    /// where n = the data entry count, q = word count of the query and m = average words per question.
    /// </summary>
    public class Engine2 : IEngine
    {
        private readonly List<DataEntry> _data;

        public Engine2(List<DataEntry> data)
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