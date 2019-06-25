using Xunit;
using SyllableCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter.Tests
{
    public class RecordTests
    {
        [Fact()]
        public void RecordIWordPairConstructorTest()
        {
            IWordReportPair pair = new WordReportPair(word: "bobblehead", report: 3);
            var target = new Record(pair);

            Assert.Equal("bobblehead", target.Word);
            Assert.Equal(3, target.UserReport);
        }
    }
}