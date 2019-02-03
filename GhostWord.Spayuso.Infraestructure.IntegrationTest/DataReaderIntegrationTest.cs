using System;
using System.IO;
using Xunit;

namespace GhostWord.Spayuso.Infraestructure.IntegrationTest
{
    public class DataReaderIntegrationTest
    {
        private readonly IDataReader _dataReader = new DataReader();

        private static string GetPathToCustomFile(string customFileName)
        {
            return (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/" + customFileName);
        }

        [Fact]
        public void DictionaryMustBeNotNullWithOnlyOneValidWord_Test()
        {
            //Arrange
            var fileName = "/Resources/fileWithOnlyOneValidWord.txt";
            var path = GetPathToCustomFile(fileName);

            //Act
            var dictionary = this._dataReader.GetDataDictionary(path);
            var length = dictionary.MaximumLength();
            var size = dictionary.Size();

            //Assert
            Assert.NotNull(dictionary);
        }

        [Fact]
        public void DictionaryMustHaveRightLengthForWord_Test()
        {
            //Arrange
            var fileName = "/Resources/fileWithOnlyOneValidWord.txt";
            var path = GetPathToCustomFile(fileName);

            //Act
            var dictionary = this._dataReader.GetDataDictionary(path);
            var length = dictionary.MaximumLength();

            //Assert
            Assert.Equal(7, length);
        }
    }
}
