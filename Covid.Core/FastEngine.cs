using System.Collections.Generic;

namespace Covid
{
    public class FastEngine : IEngine
    {
        private readonly Dictionary<string, List<DataEntry>> _dataEntriesByWordIndex;

        public FastEngine(List<DataEntry> data)
        {
            _dataEntriesByWordIndex = GetDataEntriesByWordIndex(data);
        }

        /// <summary>
        /// Creates and index with key = word and value = a list of data entries containing that word, i.e.:
        /// { "covid": [1, 5, 8], "want": [1, 2, 7, 8], "sars": [3, 4, 6, 7], ... }
        /// </summary>
        /// <param name="data">The list of DataEntries</param>
        /// <returns>The DataEntriesByWordIndex</returns>
        private Dictionary<string, List<DataEntry>> GetDataEntriesByWordIndex(List<DataEntry> data)
        {
            var index = new Dictionary<string, List<DataEntry>>();

            foreach (var item in data)
            {
                var questionWords = Tokenizer.Tokenize(item.QuestionText);

                foreach (var word in questionWords)
                {
                    if (!index.ContainsKey(word))
                    {
                        index[word] = new List<DataEntry>();
                    }
                    index[word].Add(item);
                }
            }

            return index;
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

            var scores = new Dictionary<DataEntry, int>();

            var queryWords = Tokenizer.Tokenize(query);

            foreach (var queryWord in queryWords)
            {
                if (!_dataEntriesByWordIndex.ContainsKey(queryWord))
                {
                    continue;
                }

                var matches = _dataEntriesByWordIndex[queryWord];

                foreach (var match in matches)
                {
                    if (!scores.ContainsKey(match))
                    {
                        scores[match] = 0;
                    }
                    scores[match]++;

                    if (scores[match] > bestScore)
                    {
                        bestScore = scores[match];
                        bestMatch = match;
                    }
                }
            }

            return bestMatch;
        }
    }
}