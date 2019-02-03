
using System;
using GhostWord.Spayuso.Infraestructure;
using Xunit;

namespace GhostWord.Spayuso.Infraestructure.UnitTest
{

    public class DataDictionaryTest
    {
        [Fact]
        public void DataDictionary_MustReturnNotNullDictionaryOnCreation_Test()
        {
            //Assert
            Assert.NotNull(new DataDictionary());
        }
    }
}
