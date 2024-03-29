﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    /// <summary>
    /// Maintains the history of user-input words and the syllable counts from all counting models.
    /// </summary>
    public class History
    {
        private List<IRecord> _history = new List<IRecord>();
        private readonly string _filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "history.json");

        /// <summary>
        /// Deserializes counter records.
        /// </summary>
        /// <param name="path">Optional path to the history file.  If no file path provided, path defaults to "history.json" in current directory.</param>
        public void DeserializeCounterRecords(string path = null)
        {
            // Set default if path is null
            path = (path == null) ? _filePath : path;

            var records = new List<IRecord>();
            var serializer = new JsonSerializer();

            // Check to make sure file exists
            if (File.Exists(path))
            {
                // Deserialize
                using (var reader = new StreamReader(path))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    if (File.Exists(path))
                    {
                        records = serializer.
                            Deserialize<List<Record>>(jsonReader).
                            ToList<IRecord>();
                    }
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

        public List<IRecord> ReturnAllRecordsForTesting()
        {
            return _history;
        }

        public void SerializeCounterRecords(string path = null)
        {
            // Set default if path is null
            path = (path == null) ? _filePath : path;

            var serializer = new JsonSerializer();

            using (var writer = new StreamWriter(path)) 
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, _history);
            }
        }

        /// <summary>
        /// Output records to user via Console.
        /// </summary>
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
