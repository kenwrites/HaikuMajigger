using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    interface ICounterService
    {
        List<int> Count(List<string> Words, int? method);
    }

    class CounterService : ICounterService
    {
        private readonly IModel _modelSim = new Model();  // simulates counting syllables.  For testing only.
        private readonly IModel _modelWritten = new WrittenMethod(); 
        private readonly IModel _model3 = new Model();


        public List<int> Count(List<string> Words, int? method = 1)
        {
            if (method == 1)
            {
                return _modelSim.Count(Words);
            } else if ( method == 2)
            {
                return _modelWritten.Count(Words);
            }
            else if (method == 3)
            {
                return _model3.Count(Words);
            }
            else
            {
                Console.WriteLine(method + " is not a valid method.  Enter a whole number from 1 to 3.");
                return new List<int>();   
            }
        }
    }

    
}
