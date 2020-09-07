using System.Collections.Generic;
using System.Linq;

namespace Covid.Solutions
{
    /// <summary>
    /// Second fastest version of the engine, improvement is to create a hashset from the query words
    /// so that the Contains call runs in constant time in stead of linear time.
    /// 
    /// The running time is O(qn), where q = word count of the query and n = the data entry count.
    /// </summary>
    public class Engine4 : IEngine
    {
        private readonly List<DataEntry> _data;
        private readonly Dictionary<DataEntry, HashSet<string>> _questionWords;

        public Engine4(List<DataEntry> data)
        {
            _data = data;
            _questionWords = _data.ToDictionary(x => x, x => new HashSet<string>(Tokenizer.Tokenize(x.QuestionText)));
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