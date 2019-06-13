using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SyllableCounter
{
    /// <summary>
    /// Data for training machine-learning models for syllable counting.
    /// </summary>
    class TrainingData : ITrainingData
    {
        /// <summary>
        /// UID for this training data
        /// </summary>
        public int Index { get; set; }
        public string Word { get; set; }
        public int Syllables { get; set; }
        public int Phonemes { get; set; }
    }
}
