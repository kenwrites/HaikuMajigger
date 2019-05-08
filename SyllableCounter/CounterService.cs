using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class CounterService : ISyllableCounter
    {
        public List<int> Count(List<string> Words)
        {
            int length = Words.Count();
            var counts = new List<int>();
            int i = 0;
            while (i < length)
            {
                counts.Add(2);
                i += 1;
            }
            return counts;
        }
    }

    interface ISyllableCounter
    {
        List<int> Count(List<string> Words);
    }
}
