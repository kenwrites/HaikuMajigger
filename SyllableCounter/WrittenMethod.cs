using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class WrittenMethod : Model
    {
        // This model uses the "Written Method" to count syllables by counting contiguous vowels.

        public WrittenMethod()
        {}

        public override List<int> Count(List<string> Words)
        {
            Regex vowel = new Regex("[aeiou]", RegexOptions.IgnoreCase);

            List<int> Counts = new List<int>();
            foreach (string word in Words)
            {
                int vowelCount = 0;

                // Count AEIOU

                for (int i = 0; i < word.Count(); i++)
                {
                    vowelCount = vowel.Matches(word).Count;
                }

                // Count word-ending Y

                if (word.EndsWith("y"))
                {
                    vowelCount += 1;
                }

                // Subtract word-ending E

                if (word.EndsWith("e"))
                {
                    vowelCount += 1;
                }

                Counts.Add(vowelCount);

            } // end foreach Word

            return Counts;

        } // end Count()


    }
}
