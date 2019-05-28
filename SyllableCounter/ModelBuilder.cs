using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class ModelBuilder
    {

        public static List<ITrainingData> DeserializeIPhodTrainingData()
        {
            List<ITrainingData> trainingData = new List<ITrainingData>();

            // Locate Training Data
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = Path.Combine(directory.FullName, "IPhOD2_Words_short.txt");

            // Read data into memory

            string raw;
            using (var reader = new StreamReader(path))
            {
                raw = reader.ReadToEnd();
            }

            // Get rows
            string[] stringSeparators = new string[] { "\r\n" };
            string[] rows = raw.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            // Get items & add to trainingData
            foreach (string row in rows)
            {
                string[] items = row.Split(',');

                // check to see if this is a header row
                if (items[0] == "Index")
                {
                    continue;
                }

                // assign to trainingData
                ITrainingData data = new TrainingData();
                data.Word = items[1];
                if (int.TryParse(items[0], out int index))
                {
                    data.Index = index;
                }
                if (int.TryParse(items[2], out int syllables))
                {
                    data.Syllables = syllables;
                }
                if (int.TryParse(items[3], out int phonemes))
                {
                    data.Phonemes = phonemes;
                }
                trainingData.Add(data);

            } // end trainingData.Add foreach loop
            
            return trainingData;
        }
    }


}
