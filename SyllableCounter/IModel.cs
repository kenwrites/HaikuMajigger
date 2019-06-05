using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter
{
    interface IModel
    {
        List<IRecord> Count(List<IRecord> Words);
    }
}
