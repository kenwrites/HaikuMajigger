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
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = Path.Combine(directory.FullName, "Training Data", "IPhOD2_Words.txt");
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                IEnumerable<ITrainingData> dataRecords = csv.GetRecords<ITrainingData>();
            }
            return trainingData;
        }
    }


}
