using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class Record : IRecord
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int WrittenMethodGuess { get; set; }
        public int ClassifierGuess { get; set; }
        public int UserReport { get; set; }
        public bool WrittenMethodCorrect { get
            {
                return (WrittenMethodGuess == UserReport);
            }
        }
        public bool ClassifierCorrect { get
            {
                return (ClassifierGuess == UserReport);
            }
        }

    }
}