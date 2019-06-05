using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    class Model : IModel
    {
        public Model()
        { }

        public virtual List<IRecord> Count(List<IRecord> Words)
        {
            // simulate counting syllables
            foreach (IRecord word in Words)
            {
                word.SimulatorGuess = 2;
            }
            return Words;
        }

    }

}
