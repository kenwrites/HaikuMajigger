﻿using System;
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
            // get words from the user

            List<string> WordList = new List<string>();
            List<int> UserReportList = new List<int>();

            Console.WriteLine("Enter words for which you want to count syllables.  Hit \"enter\" between each.  Write \"count\" after your last word.");

            const int maxWords = 100;
            Regex digits = new Regex("[0-9]");

            do
            {
                string NewWord = Console.ReadLine();
                if (NewWord.ToLower() == "count")
                {
                    break;
                }
                else if (digits.IsMatch(NewWord))
                {
                    Console.WriteLine("Please do not enter any words with number characters (i.e. 0-9).");
                }
                else
                {
                    WordList.Add(NewWord.ToLower());
                }

                // Get report of syllable count from user 
                Console.Write(string.Format("How many syllables does {0} have? ", NewWord));
                bool keepGoing = true;
                do
                {
                    bool UserReportIsValid = int.TryParse(Console.ReadLine(), out int userReport);
                    if (UserReportIsValid && userReport > 0)
                    {
                        UserReportList.Add(userReport);
                        keepGoing = false;
                    }
                    else
                    {
                        Console.Write("Sorry, there was a problem with your entry.  Please enter a whole number greater than 0.");
                    }
                } while (keepGoing);
            }
            while (WordList.Count() < maxWords);

            // send words to syllable-counter service

            List<int> WrittenMethodSyllableCounts = CounterService.Count(WordList, ModelSelection.Written);
            List<int> ClassifierSyllableCounts = CounterService.Count(WordList, ModelSelection.Option3);

            // on receiving syllable count, output to user

            if (WrittenMethodSyllableCounts.Count() == WordList.Count())
            {
                Console.WriteLine("Your words have this many syllables: ");
                for (int i = 0; i < WrittenMethodSyllableCounts.Count; i++)
                {
                    Console.WriteLine(WordList[i] + " has " + WrittenMethodSyllableCounts[i] + " syllables.");
                }
            }
            else
            {
                Console.WriteLine("We're sorry:  There was a problem with the syllable counter.");
            }

            // Build Record, and add to History
            var _history = new History();
            for (int i = 0; i < WordList.Count; i++)
            {
                IRecord _record = new Record();
                int _lastID = _history.ReadCounterRecord(1)[0].Id;
                _record.Id = _lastID++;
                _record.Word = WordList[i];
                _record.WrittenMethodGuess = WrittenMethodSyllableCounts[i];
                _record.ClassifierGuess = ClassifierSyllableCounts[i];
                _record.UserReport = UserReportList[i];
                _history.AddCounterRecord(_record);

            }

            Console.ReadKey();

            // Convert training data to JSON

            //List<ITrainingData> trainingData = ModelBuilder.DeserializeIPhodTrainingData();
            //ModelBuilder.SerializeTrainingDataAsJson(trainingData);
            //Console.ReadLine();

        } // end Main()
    } // end Program
}  // end namespace
