using System;
using System.Diagnostics;

namespace Covid
{
    [DebuggerDisplay("{QuestionText}")]
    public class DataEntry
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public DateTime TimeStamp { get; set; }

        public static DataEntry Parse(string text)
        {
            var dataEntry = new DataEntry();
            var items = text.Split('|');
            dataEntry.QuestionId = int.Parse(items[0]);
            dataEntry.CategoryId = int.Parse(items[1]);
            dataEntry.QuestionText = items[2];
            dataEntry.AnswerText = items[3];
            dataEntry.TimeStamp = DateTime.Parse(items[4]);
            return dataEntry;
        }
    }
}