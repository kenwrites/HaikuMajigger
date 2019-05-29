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
                records = serializer.
                    Deserialize<List<Record>>(jsonReader).
                    ToList<IRecord>();
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
            if (_history.Count == 0)
            {
                return new List<IRecord> { new Record() };
            }

            // otherwise, return the smaller of:  numRecords, or _history.Count
            var _records = new List<IRecord>();
            numRecords = (numRecords <= _history.Count) ? numRecords : _history.Count;
            int lastRecordIndex = _history.Count - 1;
            for (int i = 0; i < numRecords; i++)
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
    }
}
