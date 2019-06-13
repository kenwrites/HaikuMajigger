using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    /// <summary>
    /// A Model is a way of counting syllables.  Unless overriden, the default behavior just returns '2' for each word.  This is for testing purposes.  Override this behavior when implementing a new model.  
    /// </summary>
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
