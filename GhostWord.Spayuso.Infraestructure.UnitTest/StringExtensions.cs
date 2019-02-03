using System;
using Xunit;

namespace GhostWord.Spayuso.Infraestructure.UnitTest
{
    public class StringExtensionsTest
    {
        [Fact]
        public void StringExtensions_GetLetterFromStringPosition_MustReturnStringType_Test()
        {
            //Arrange
            var stringToTest = "string";

            //Act
            var result = stringToTest.GetLetterFromStringPosition(1);

            //Assert
            Assert.True(result is string);
        }

        [Fact]
        public void StringExtensions_GetLetterFromStringPosition_MustReturnRightLetter_Test()
        {
            //Arrange
            var stringToTest = "string";

            //Act
            var result = stringToTest.GetLetterFromStringPosition(1);

            //Assert
            Assert.Equal("t", result);
        }

        [Fact]
        public void StringExtensions_GetLetterFromStringPosition_MustReturnEmptyStringIfStringIsEmpty_Test()
        {
            //Arrange
            var stringToTest = string.Empty;

            //Act
            Action action = () => stringToTest.GetLetterFromStringPosition(1);

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        } 

        [Fact]
        public void StringExtensions_GetLetterFromStringPosition_MustThrowArgumentNullExceptionIfStringIsNull_Test()
        {
            //Arrange
            string stringToTest = null;

            //Act
            Action action = () => stringToTest.GetLetterFromStringPosition(1);

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
