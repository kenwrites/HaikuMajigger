using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class UserConsole
    {
        static readonly ISyllableCounter CounterService = new CounterService();
        static void Main()
        {
            // get words from the user

            List<string> WordList = new List<string>();

            Console.WriteLine("Enter words for which you want to count syllables.  Hit \"enter\" between each.  Write \"quit\" after you last word.");

            while (true)
            {
                string NewWord = Console.ReadLine();
                
                if (NewWord.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                     WordList.Add(NewWord);
                }

            } // end while

            // send words to syllable-counter service
            List<int> SyllableCounts = CounterService.Count(WordList);

            // on receiving syllable count, output to user
            Console.WriteLine("Your words have this many syllables: ");
            int i = 0;
            int counts = SyllableCounts.Count;

            while (i < counts)
            {
                Console.WriteLine(WordList[i] + " has " + SyllableCounts[i] + " syllables.");
                i += 1;
            }

            string pause = Console.ReadLine();

        } // end Main()
    } // end UserConsole

    //public class WordList : IWords
    //{
    //    List<string> _words;
    //    public List<string> Words;
    //    //{
    //    //    get => _words;
    //    //    set => _words = value;
    //    //}
    //}

    //interface IWords
    //{
    //    List<string> Words { get; set; }
    //}



}  // end namespace
