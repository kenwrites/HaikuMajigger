using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyllableCounter
{
    interface ICounterService
    {
        List<IRecord> Count(List<IRecord> Words, ModelSelection? model);
        List<IWordReportPair> GetUserInput();
    }

    interface IWordReportPair
    {
        string Word { get; set; }
        int UserReport { get; set; }
    }

    class WordReportPair : IWordReportPair
    {
        public string Word { get; set; }
        public int UserReport { get; set; }

        public WordReportPair(string word, int report)
        {
            Word = word;
            UserReport = report;
        }
    }

    enum ModelSelection
    {
        Simulator,
        Written,
        Option3
    }

    class CounterService : ICounterService
    {
        // Initialize Models
        private readonly IModel _modelSim = new Model();  // simulates counting syllables.  For testing only.
        private readonly IModel _modelWritten = new WrittenMethod();  // counts syllables with the "Written Method".  Basically:  counts sets of contiguous vowels.
        private readonly IModel _model3 = new Model();

        // Methods
        public List<IRecord> Count(List<IRecord> Words, ModelSelection? model)
        {
            if (model == ModelSelection.Simulator)
            {
                return _modelSim.Count(Words);
            } else if (model == ModelSelection.Written)
            {
                return _modelWritten.Count(Words);
            }
            else if (model == ModelSelection.Option3)
            {
                return _model3.Count(Words);
            }
            else
            {
                Console.WriteLine(model + " is not a valid model selection.");
                return new List<IRecord>();   
            }
        }
        public List<IWordReportPair> GetUserInput()
        {           
            var wordReportPairs = new List<IWordReportPair>();

            Console.WriteLine("\r\nEnter words for which you want to count syllables.  Hit \"enter\" between each.  Write \"count\" after your last word.  You will also enter the number of syllables you hear in each word, so that we can tell if the program is guessing correctly.");

            const int maxWords = 100;
            Regex digits = new Regex("[0-9]");

            bool keepGettingWords = true;
            do
            {
                Console.Write("Enter word: ");
                string NewWord = Console.ReadLine();

                // Validate input 
                if (digits.IsMatch(NewWord))
                {
                    Console.WriteLine("Please do not enter any words with number characters (i.e. 0-9).");
                }
                else
                {
                    // Get report of syllable count from user 
                    Console.Write($"How many syllables does {NewWord} have? ");
                    bool keepGettingUserReport = true;
                    do
                    {
                        bool UserReportIsValid = int.TryParse(Console.ReadLine(), out int userReport);
                        if (UserReportIsValid && userReport > 0)
                        {
                            // If valid, Add wordReportPair to list
                            wordReportPairs.Add(new WordReportPair(NewWord, userReport));
                            keepGettingUserReport = false;
                        }
                        // Handle input issues
                        else
                        {
                            Console.Write("Sorry, there was a problem with your entry.  Please enter a whole number greater than 0.");
                        }
                    } while (keepGettingUserReport);

                    // Confirm that user wants to enter another word

                    Console.Write("Enter another word? (Y/n) ");
                    bool keepConfirmingMoreWords = true;
                    do
                    {
                        string input = Console.ReadLine().ToLower();
                        if (input == "n" ||
                            input == "no")
                        {
                            keepGettingWords = false;
                            keepConfirmingMoreWords = false;
                            continue;
                        }
                        else if (input == "y" ||
                          input == "yes" ||
                          string.IsNullOrEmpty(input))
                        {
                            keepConfirmingMoreWords = false;
                            continue;
                        }
                        else
                        {
                            Console.Write("Sorry, there was a problem with your input.  Please enter \"Y\" for yes, \"N\" for no: ");
                        }
                    } while (keepConfirmingMoreWords);
                }
            } while (
                wordReportPairs.Count() < maxWords && 
                keepGettingWords);
            return wordReportPairs;
        }
    }    
}
