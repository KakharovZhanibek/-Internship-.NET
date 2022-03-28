using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorWithCommandPattern.Interfaces;

namespace TextEditorWithCommandPattern
{
    public class TextEditor
    {
        public List<string> Text = new List<string>();

        public int CurrentXCoordinate { get; set; } = 0;
        public int CurrentYCoordinate { get; set; } = 0;

        public void MoveCursorTo(int x, int y)
        {
            MoveCursorToOperation moveCursorToOperation = new MoveCursorToOperation(x, y, this);
            moveCursorToOperation.Execute();
        }
        public void InsertChar(char symbol)
        {
            InsertCharOperation insertCharOperation = new InsertCharOperation(symbol, this);
            insertCharOperation.Execute();
        }
        public void DeleteChar()
        {
            DeleteCharOperation deleteCharOperation = new DeleteCharOperation(this);
            deleteCharOperation.Execute();
        }

        public class MoveCursorToOperation : IOperation
        {
            private readonly int xCoordinate;
            private readonly int yCoordinate;
            private readonly TextEditor TextEditor;

            private bool isComplete;
            public bool IsComplete { get => isComplete; }

            public MoveCursorToOperation(int x, int y, TextEditor textEditor)
            {
                xCoordinate = x;
                yCoordinate = y;

                this.TextEditor = textEditor;
            }
            public void Execute()
            {
                TextEditor.CurrentXCoordinate = xCoordinate;
                TextEditor.CurrentYCoordinate = yCoordinate;

                isComplete = true;
            }
        }
        public class InsertCharOperation : IOperation
        {
            private readonly char InsertingSymbol;
            private readonly TextEditor TextEditor;

            private bool isComplete;
            public bool IsComplete { get => isComplete; }


            public InsertCharOperation(char insertingSymbol, TextEditor textEditor)
            {
                InsertingSymbol = insertingSymbol;
                TextEditor = textEditor;
            }
            public void Execute()
            {

                if (TextEditor.Text.Count <= TextEditor.CurrentXCoordinate)
                {
                    do
                    {
                        TextEditor.Text.Add("");
                    }
                    while (TextEditor.Text.Count <= TextEditor.CurrentXCoordinate);
                }

                if (TextEditor.Text[TextEditor.CurrentXCoordinate].Length <= TextEditor.CurrentYCoordinate)
                {
                    while (TextEditor.Text[TextEditor.CurrentXCoordinate].Length != TextEditor.CurrentYCoordinate)
                    {
                        TextEditor.Text[TextEditor.CurrentXCoordinate] += ' ';
                    }

                    TextEditor.Text[TextEditor.CurrentXCoordinate] += InsertingSymbol;
                }
                else if (TextEditor.Text[TextEditor.CurrentXCoordinate].Length > TextEditor.CurrentYCoordinate)
                {
                    TextEditor.Text[TextEditor.CurrentXCoordinate].Insert(TextEditor.CurrentYCoordinate, InsertingSymbol.ToString());
                }
                TextEditor.CurrentYCoordinate++;

                isComplete = true;
            }
            public void Undo()
            {

            }
            public void Redo()
            {

            }
        }
        class DeleteCharOperation : IOperation
        {
            private readonly TextEditor TextEditor;

            private bool isComplete;
            public bool IsComplete { get => isComplete; }

            public DeleteCharOperation(TextEditor textEditor)
            {
                TextEditor = textEditor;
            }
            public void Execute()
            {
                TextEditor.Text[TextEditor.CurrentXCoordinate] = TextEditor.Text[TextEditor.CurrentXCoordinate].Remove(TextEditor.CurrentYCoordinate - 1, 1);
                TextEditor.CurrentYCoordinate--;

                isComplete = true;
            }
        }
    }
}
