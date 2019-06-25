using Xunit;
using SyllableCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableCounter.Tests
{
    public class CounterServiceTests
    {
        [Fact()]
        public void Count_WrittenMethod_Test()
        {
            var words = new List<IRecord>
            {
                new Record{Id = 1, Word = "Bob", UserReport = 1},
                new Record{Id = 2, Word = "made", UserReport = 1},
                new Record{Id = 3, Word = "abracadabra", UserReport = 5},
                new Record{Id = 4, Word = "meany", UserReport = 2},
                new Record{Id = 5, Word = "margeaux", UserReport = 2},
                new Record{Id = 5, Word = "really", UserReport = 2},

            };
            var counterService = new CounterService();
            var target = counterService.Count(words, ModelSelection.Written);


            Assert.True(target[0].WrittenMethodGuess == 1);
            Assert.True(target[1].WrittenMethodGuess == 1);
            Assert.True(target[2].WrittenMethodGuess == 5);
            Assert.True(target[3].WrittenMethodGuess == 2);
            Assert.True(target[4].WrittenMethodGuess == 2);
            Assert.True(target[5].WrittenMethodGuess == 2);

        }


    }
}