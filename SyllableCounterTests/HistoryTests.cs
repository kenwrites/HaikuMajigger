using Xunit;
using SyllableCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SyllableCounter.Tests
{
    public class HistoryTests
    {
        History history = new History();

        [Fact()]
        public void DeserializeCounterRecordsTest()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "history.json");
            history.DeserializeCounterRecords(filePath);
            var target = history.ReturnAllRecordsForTesting();

            Assert.True(target[1].Word == "testTESTtest");
        }

        [Fact()]
        public void DeserializeCounterRecords_WhenNoFileExists_Test()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "nothinghere.json");
            history.DeserializeCounterRecords(filePath);
            var target = history.ReturnAllRecordsForTesting();

            Assert.False(target.Any());
        }

        [Fact()]
        public void AddCounterRecordTest()
        {
            var record = new Record { Word = "AddCounterRecordTest" };
            history.AddCounterRecord(record);
            var target = history.ReturnAllRecordsForTesting();

            Assert.True(target.Last().Word == "AddCounterRecordTest");

        }

        [Fact()]
        public void ReadCounterRecordsTest()
        {
            var target = history.ReadCounterRecords(1);
            Assert.True(target.GetType() == typeof(List<IRecord>));
            Assert.True(target.Count() == 1);
        }

        [Fact]
        public void ReadCounterRecords_AskingForMoreRecordsThanPresent_Test()
        {

            // Note:  this test depends on the DeserializeCounterRecords method.  If this test fails, first verify that DeserializeCounterRecords is working.

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "history.json");
            history.DeserializeCounterRecords(filePath);
            var target = history.ReadCounterRecords(100);

            Assert.True(target.GetType() == typeof(List<IRecord>));
            Assert.True(target.Count() == 3);
        }

        [Fact()]
        public void SerializeCounterRecordsTest()
        {
            // Note:  this test depends on the DeserializeCounterRecords method.  If this test fails, first verify that DeserializeCounterRecords is working.

            string path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "output.json");
            File.Delete(path);

            string testDataPath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "SerializeCounterRecordsTest_Input.json");

            List<IRecord> expected = new List<IRecord>
            {
                new Record{Word = "SerializeCounterRecordsTest"},
                new Record{Word = "StillTestingSerializeCounterRecords"},
            };

            history.DeserializeCounterRecords(testDataPath);
            history.SerializeCounterRecords(path);

            history.DeserializeCounterRecords(path);
            var target = history.ReturnAllRecordsForTesting();

            Assert.True(target[1].Word == "StillTestingSerializeCounterRecords");
        }
    }
}