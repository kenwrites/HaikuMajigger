using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SyllableCounter
{
    class TrainingData : ITrainingData
    {
        public int Index { get; set; }
        public string Word { get; set; }
        public int Syllables { get; set; }
        public int Phonemes { get; set; }
    }
}
