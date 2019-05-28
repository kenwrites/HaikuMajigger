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

        public virtual List<int> Count(List<string> Words)
        {
            // simulate counting syllables
            var counts = new List<int>();
            foreach (string word in Words)
            {
                counts.Add(2);
            }
            return counts;
        }

    }

}
