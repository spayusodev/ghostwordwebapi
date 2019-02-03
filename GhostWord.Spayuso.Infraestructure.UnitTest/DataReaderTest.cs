using System;
using Xunit;

namespace GhostWord.Spayuso.Infraestructure.UnitTest
{
    public class DataReaderTest
    {
        private readonly IDataReader _dataReader = new DataReader();


        [Fact]
        public void DataReaderMustThrowFileNotFoundExceptionIfFileDoesNotExists_Test()
        {
            //Act
            Action action = () => this._dataReader.GetDataDictionary("testFile");

            //Assert
            Assert.Throws<System.IO.FileNotFoundException>(action);
        }

        [Fact]
        public void DataReaderMustReturnNotNullDataDictionary_Test()
        {
            //Arrange
            var fileName = "gosthGameDict.txt";

            //Act 
            var dataDictionary = this._dataReader.GetDataDictionary(fileName);

            //Assert
            Assert.NotNull(dataDictionary);
        }
    }
}
