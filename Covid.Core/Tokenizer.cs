using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Covid
{
    public static class Tokenizer
    {
        public static List<string> Tokenize(string text)
        {
            return Regex
                .Matches(text.ToLower(), @"\w+")
                .Select(x => x.Value)
                .Distinct()
                .ToList();
        }
    }
}