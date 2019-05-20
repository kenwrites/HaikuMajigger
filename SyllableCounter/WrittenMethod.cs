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
            Regex vowel = new Regex("[aeiou]");
            Regex tripthong = new Regex("[aeiou]{3}");
            Regex dipthong = new Regex("[aeiou]{2}");

            List<int> Counts = new List<int>();
            foreach (string word in Words)
            {
                int syllables = 0;

                // Count AEIOU

                for (int i = 0; i < word.Count(); i++)
                {
                    syllables = vowel.Matches(word).Count;
                }

                // Count word-ending Y

                if (word.EndsWith("y"))
                {
                    syllables += 1;
                }

                // Subtract word-ending E

                if (word.EndsWith("e"))
                {
                    syllables += 1;
                }

                // Subtract dipthongs and tripthongs (when 2 or 3 vowels make only 1 sound, like the "ea" in "heaven")               

                int dipthongs = dipthong.Matches(word).Count;
                int tripthongs = tripthong.Matches(word).Count;
                syllables = syllables - (dipthongs - tripthongs) - (tripthongs * 2);

                // Record syllable count for this word in Counts list

                Counts.Add(syllables);

            } // end foreach Word

            return Counts;

        } // end Count()


    }
}
