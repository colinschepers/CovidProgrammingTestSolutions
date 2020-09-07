﻿using System.Collections.Generic;

namespace Covid.Solutions
{
    /// <summary>
    /// The slowest version of the engine.
    /// 
    /// The running time is O(nqmqm) = O(n * q^2 * m^2), 
    /// where q = word count of the query, n = the data entry count and m = average words per question.
    /// </summary>
    public class Engine1 : IEngine
    {
        private readonly List<DataEntry> _data;

        public Engine1(List<DataEntry> data)
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
                var queryWords = Tokenizer.Tokenize(query);
                var questionWords = Tokenizer.Tokenize(item.QuestionText);
                var score = 0;

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