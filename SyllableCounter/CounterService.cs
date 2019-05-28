using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    interface ICounterService
    {
        List<int> Count(List<string> Words, ModelSelection? model);
    }

    enum ModelSelection
    {
        Simulator,
        Written,
        Option3
    }

    class CounterService : ICounterService
    {
        private readonly IModel _modelSim = new Model();  // simulates counting syllables.  For testing only.
        private readonly IModel _modelWritten = new WrittenMethod();  // counts syllables with the "Written Method".  Basically:  counts sets of contiguous vowels.
        private readonly IModel _model3 = new Model();


        public List<int> Count(List<string> Words, ModelSelection? model)
        {
            if (model == ModelSelection.Simulator)
            {
                return _modelSim.Count(Words);
            } else if (model == ModelSelection.Written)
            {
                return _modelWritten.Count(Words);
            }
            else if (model == ModelSelection.Option3)
            {
                return _model3.Count(Words);
            }
            else
            {
                Console.WriteLine(model + " is not a valid model selection.");
                return new List<int>();   
            }
        }
    }

    
}
