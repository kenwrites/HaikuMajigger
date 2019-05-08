using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class UserConsole
    {
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

            // send word to syllable-counter service

            // on receiving syllable count, output to user

            // repeat until user enters 'quit'
        }
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

    interface ISyllableCounter
    {
        int[] Count(List<string> WordsToCount);
    }

}  // end namespace
