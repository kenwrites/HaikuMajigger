using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    interface IModel
    {
        List<int> Count(List<string> Words);
    }
}
