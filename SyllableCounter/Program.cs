using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SyllableCounter
{
    class Program
    {
        static readonly ICounterService CounterService = new CounterService();
        static void Main()
        {
            //// get words from the user

            //List<string> WordList = new List<string>();

            //Console.WriteLine("Enter words for which you want to count syllables.  Hit \"enter\" between each.  Write \"count\" after you last word.");

            //const int maxWords = 100;
            //Regex digits = new Regex("[0-9]");

            //do
            //{
            //    string NewWord = Console.ReadLine();
            //    if (NewWord.ToLower() == "count")
            //    {
            //        break;
            //    }
            //    else if (digits.IsMatch(NewWord))
            //    {
            //        Console.WriteLine("Please do not enter any words with number characters (i.e. 0-9).");
            //    }
            //    else
            //    {
            //        WordList.Add(NewWord.ToLower());
            //    }
            //}
            //while (WordList.Count() < maxWords);

            //// send words to syllable-counter service

            //List<int> SyllableCounts = CounterService.Count(WordList, ModelSelection.Written);

            //// on receiving syllable count, output to user

            //if (SyllableCounts.Count() == WordList.Count())
            //{
            //    Console.WriteLine("Your words have this many syllables: ");
            //    for (int i = 0; i < SyllableCounts.Count; i++)
            //    {
            //        Console.WriteLine(WordList[i] + " has " + SyllableCounts[i] + " syllables.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("We're sorry:  There was a problem with the syllable counter.");
            //}

            //string pause = Console.ReadLine();

            List<ITrainingData> trainingData = ModelBuilder.DeserializeIPhodTrainingData();
            foreach(ITrainingData data in trainingData)
            {
                Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", data.Index, data.Word, data.Syllables, data.Phonemes));
            }
            ModelBuilder.SerializeTrainingDataAsJson(trainingData);
            Console.ReadLine();


        } // end Main()
    } // end Program
}  // end namespace
