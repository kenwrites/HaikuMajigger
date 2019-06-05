using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class History
    {
        private List<IRecord> _history = new List<IRecord>();
        private string _filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "history.json");

        public void DeserializeCounterRecords()
        {
            var records = new List<IRecord>();
            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(_filePath))
            using (var jsonReader = new JsonTextReader(reader))
            {
                if (File.Exists(_filePath))
                {
                    records = serializer.
                        Deserialize<List<Record>>(jsonReader).
                        ToList<IRecord>();
                }               
            }
            _history = records;
        }

        public void AddCounterRecord(IRecord record)
        {
            _history.Add(record);
        }

        public List<IRecord> ReadCounterRecords(int numRecords)
        {
            // if no records, return a single empty Record
            if (!_history.Any())
            {
                return new List<IRecord> { new Record() };
            }

            // otherwise, return the smaller of:  numRecords, or _history.Count
            var _records = new List<IRecord>();
            int lastRecordIndex = _history.Count - 1;
            for (int i = 0; i < numRecords && i < _history.Count; i++)
            {
                _records.Add(_history[lastRecordIndex - i]);
            }
            return _records;
        }

        public void SerializeCounterRecords()
        {
            var serializer = new JsonSerializer();

            using (var writer = new StreamWriter(_filePath)) 
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, _history);
            }
        }

        public void PrintRecords()
        {
            // Validate input
            Console.Write("\r\nHow many records do you want to read? ");
            if (int.TryParse(Console.ReadLine(), out int numRecords))
            {
                if (numRecords > 0)
                {
                    // Get record and display them
                    List<IRecord> _records = ReadCounterRecords(numRecords);
                    foreach (var record in _records)
                    {
                        Console.WriteLine("\r\nWord: {0} " +
                            "\r\nWritten Method Guess: {1} ({2}) " +
                            "\r\nClassifier Guess: {3} ({4}) \r\n",
                            record.Word,
                            record.WrittenMethodGuess,
                            (record.WrittenMethodCorrect) ? "Correct" : "Incorrect",
                            record.ClassifierGuess,
                            (record.ClassifierCorrect) ? "Correct" : "Incorrect");
                    }
                }
                // Handle input issues
                else
                {
                    Console.WriteLine("\r\nSorry, I cannot retrieve {0} records.  Please enter a whole number greater than 0.", numRecords);
                }
            }
            else
            {
                Console.WriteLine("\r\nSorry, there was a problem with your entry.  Please enter a whole number greater than 0.");
            }
        }
    }
}
