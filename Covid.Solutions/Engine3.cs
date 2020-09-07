using System.Collections.Generic;
using System.Linq;

namespace Covid.Solutions
{
    /// <summary>
    /// Third slowest version of the engine, improvement is to move the costly question string tokenization
    /// to the initialization of the engine (preprocessing) so that it does not have to be done during query time.
    /// 
    /// The running time is O(nqm), 
    /// where n = the data entry count, q = word count of the query and m = average words per question.
    /// </summary>
    public class Engine3 : IEngine
    {
        private readonly List<DataEntry> _data;
        private readonly Dictionary<DataEntry, List<string>> _questionWords;

        public Engine3(List<DataEntry> data)
        {
            _data = data;
            _questionWords = _data.ToDictionary(x => x, x => Tokenizer.Tokenize(x.QuestionText));
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

                var questionWords = _questionWords[item];

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