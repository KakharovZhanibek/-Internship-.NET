using System;
using TextEditorWithCommandPattern.Classes;
using Xunit;

namespace TextEditorWithCommandPattern.Tests
{
    public class TextEditorTests
    {
        [Fact]
        public void MoveCursorTo_ToIncomingCoordinates()
        {
            //Arrange
            TextEditor textEditor = new TextEditor();
            int expectedXCoordinate = 5;
            int expectedYCoordinate = 16;
            //Act

            textEditor.MoveCursorTo(expectedXCoordinate, expectedYCoordinate);

            int actualXCoordinate = textEditor.CurrentXCoordinate;
            int actualYCoordinate = textEditor.CurrentYCoordinate;
            //Assert
            Assert.Equal(expectedXCoordinate, actualXCoordinate);
            Assert.Equal(expectedYCoordinate, actualYCoordinate);
        }

        [Fact]
        public void InsertChar_ToCurrentCursorPosition()
        {
            //Arrange
            TextEditor textEditor = new TextEditor();
            char expectedChar = 'F';

            //Act

            textEditor.InsertChar(expectedChar);

            char actualChar = textEditor.Text[textEditor.CurrentXCoordinate][textEditor.CurrentYCoordinate - 1];
            //Assert
            Assert.Equal(expectedChar, actualChar);
        }

        [Fact]
        public void DeleteChar_FromCurrentCursorPosition()
        {
            //Arrange
            TextEditor textEditor = new TextEditor();

            string testString = "Qwertyuiop";

            textEditor.Text.Add(testString);
            textEditor.CurrentYCoordinate = 8;

            string expectedString = "Qwertyuop";
            //Act
            textEditor.DeleteChar();

            string actualString = textEditor.Text[textEditor.CurrentXCoordinate];
            //Assert
            Assert.Equal(expectedString, actualString);
        }
    }
}
