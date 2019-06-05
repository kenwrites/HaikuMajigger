using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    public class CountedWord
    {
        public string Word { get; set; }
        public int SyllableCount { get; set; }
    }
    public class WordListManager
    {
        public const int MAX_WORDS = 100;
        //just an idea
        private Dictionary<string, int> dictionary;
        private List<string> WordList = new List<string>();
        private List<int> UserReportList = new List<int>();
        public void AddWord(string newWord)
        {
            //check regex
            //set lowercase
            //add to internal list
        }
    }
}
