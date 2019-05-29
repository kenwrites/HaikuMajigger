﻿using Newtonsoft.Json;
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
        private List<Record> _history = new List<Record>();
        private string _filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "history.json");
        public void DeserializeCounterRecords()
        {
            var records = new List<Record>();
            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(_filePath))
            using (var jsonReader = new JsonTextReader(reader))
            {
                records = serializer.Deserialize<List<Record>>(jsonReader);
            }
            _history = records;
        }

        public void AddCounterRecord(Record record)
        {
            _history.Add(record);
        }

        public List<Record> ReadCounterRecord(int numRecords)
        {
            // if no records, return a single empty Record
            if (_history.Count == 0)
            {
                return new List<Record> { new Record() };
            }

            // otherwise, return the smaller of:  numRecords, or _history.Count
            var records = new List<Record>();
            numRecords = (numRecords <= _history.Count) ? numRecords : _history.Count;
            int lastRecordIndex = _history.Count - 1;
            for (int i = 0; i < numRecords; i++)
            {
                records.Add(_history[lastRecordIndex - i]);
            }
            return records;
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
    }
}