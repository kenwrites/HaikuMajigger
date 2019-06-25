using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyllableCounter
{
    /// <summary>
    /// This model uses the "Written Method" to count syllables by counting contiguous vowels.
    /// </summary>
    class WrittenMethod : IModel
    {
        public WrittenMethod()
        {}

        public List<IRecord> Count(List<IRecord> Words)
        {
            Regex vowel = new Regex("[aeiou]");
            Regex tripthong = new Regex("[aeiou]{3}");
            Regex dipthong = new Regex("[aeiou]{2}");

            foreach (IRecord record in Words)
            {
                int syllables = 0;

                // Count AEIOU

                for (int i = 0; i < record.Word.Count(); i++)
                {
                    syllables = vowel.Matches(record.Word).Count;
                }

                // Count word-ending Y

                if (record.Word.EndsWith("y"))
                {
                    syllables += 1;
                }

                // Subtract word-ending E

                if (record.Word.EndsWith("e"))
                {
                    syllables -= 1;
                }

                // Subtract dipthongs and tripthongs (when 2 or 3 vowels make only 1 sound, like the "ea" in "heaven")               

                int dipthongs = dipthong.Matches(record.Word).Count;
                int tripthongs = tripthong.Matches(record.Word).Count;
                syllables = syllables - (dipthongs - tripthongs) - (tripthongs * 2);

                // Record syllable count for this word in Counts list

                record.WrittenMethodGuess = syllables;

            } // end foreach Word

            return Words;

        } // end Count()


    } // end WrittenMethod
}
