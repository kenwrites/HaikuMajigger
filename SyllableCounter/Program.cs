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
        static readonly ICounterService counterService = new CounterService();

        static void CountSyllables(History _history)
        {
            // get words from the user
            List<IWordReportPair> wordReportPairs = counterService.GetUserInput();
            // convert to Records
            List<IRecord> userRecords = new List<IRecord>();
            foreach (IWordReportPair pair in wordReportPairs)
            {
                userRecords.Add(new Record(pair));
            }

            // send Records to syllable-counter service

            List<IRecord> SimulatedSyllableCounts = counterService.Count(
                userRecords,
                ModelSelection.Simulator);

            List<IRecord> WrittenMethodSyllableCounts = counterService.Count(
                SimulatedSyllableCounts,
                ModelSelection.Written);

            // Below code will call machine-learning syllable counter model, when it's ready

            //List<IRecord> ClassifierSyllableCounts = counterService.Count(
            //    WrittenMethodSyllableCounts,
            //    ModelSelection.Option3);

            // On receiving syllable count, output to user
            Console.WriteLine("According to the \"Written Method\", your words have this many syllables: ");
            foreach (IRecord record in WrittenMethodSyllableCounts)
            {
                Console.WriteLine($"{record.Word} has {record.WrittenMethodGuess} syllables.  ({record.WrittenMethodCorrect})");
            }

            // Add to History
            foreach (IRecord record in WrittenMethodSyllableCounts)
            {
                _history.AddCounterRecord(record);
            }

            // Write History to disk
            _history.SerializeCounterRecords();
        }

        static void Main()
        {
            // Initialize History
            var _history = new History();           
            _history.DeserializeCounterRecords();

            // Prompt user choice:  read history or count new words?  

            bool keepPromptingUserChoice = true;
            do
            {
                Console.WriteLine("\r\nWhat would you like to do?  Enter " +
                "\r\n - 1 to enter new words for syllable counter" +
                "\r\n - 2 to view counter history" +
                "\r\n - 3 to exit");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    // Count Syllables
                    if (choice == 1)
                    {
                        CountSyllables(_history);
                    }
                    // Read History
                    if (choice == 2)
                    {
                        _history.PrintRecords();
                    }
                    // Exit
                    if (choice == 3)
                    {
                        keepPromptingUserChoice = false;
                    }
                }
                // If TryParse fails, then:
                else
                {
                    Console.WriteLine("Sorry, there was a problem with your input.  Please enter 1, 2, or 3. \r\n");
                }
            } while (keepPromptingUserChoice);

            // Convert training data to JSON

            //List<ITrainingData> trainingData = ModelBuilder.DeserializeIPhodTrainingData();
            //ModelBuilder.SerializeTrainingDataAsJson(trainingData);
            //Console.ReadLine();

        } // end Main()
    } // end Program
}  // end namespace
