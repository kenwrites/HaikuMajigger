using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace SyllableCounter
{
    class TrainingData : ITrainingData
    {
        [Name("Indx")]
        public int Index { get; set; }
        public string Word { get; set; }
        [Name("NSyll")]
        public int Syllables { get; set; }
        [Name("NPhon")]
        public int Phonemes { get; set; }
    }
}
