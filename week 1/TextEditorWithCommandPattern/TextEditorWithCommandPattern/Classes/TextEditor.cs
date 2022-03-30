using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorWithCommandPattern.Interfaces;

namespace TextEditorWithCommandPattern.Classes
{
    public class TextEditor
    {
        public List<string> Text = new List<string>();

        public int CurrentXCoordinate { get; set; } = 0;
        public int CurrentYCoordinate { get; set; } = 0;
        private Stack<IOperation> UndoOperations { get; set; }
        private Stack<IOperation> RedoOperations { get; set; }
        public TextEditor()
        {
            UndoOperations = new Stack<IOperation>();
            RedoOperations = new Stack<IOperation>();
        }
        public void MoveCursorTo(int x, int y)
        {
            MoveCursorToOperation moveCursorToOperation = new MoveCursorToOperation(x, y, this);
            moveCursorToOperation.Execute();
            if (RedoOperations.Any())
                RedoOperations.Clear();
            UndoOperations.Push(moveCursorToOperation);
        }
        public void InsertChar(char symbol)
        {
            InsertCharOperation insertCharOperation = new InsertCharOperation(symbol, this);
            insertCharOperation.Execute();
            if (RedoOperations.Any())
                RedoOperations.Clear();
            UndoOperations.Push(insertCharOperation);
        }
        public void DeleteChar()
        {
            DeleteCharOperation deleteCharOperation = new DeleteCharOperation(this);
            deleteCharOperation.Execute();
            if (RedoOperations.Any())
                RedoOperations.Clear();
            UndoOperations.Push(deleteCharOperation);
        }

        public void Undo()
        {
            if (UndoOperations.Any())
                UndoOperations.Peek().Undo();

        }
        public void Redo()
        {
            if (RedoOperations.Any())
                RedoOperations.Peek().Redo();
        }

        public class MoveCursorToOperation : IOperation
        {
            private readonly int XCoordinate;
            private readonly int YCoordinate;
            private readonly TextEditor TextEditor;
            private readonly int PreviousXCoordinate;
            private readonly int PreviousYCoordinate;

            public MoveCursorToOperation(int x, int y, TextEditor textEditor)
            {
                XCoordinate = x;
                YCoordinate = y;

                PreviousXCoordinate = textEditor.CurrentXCoordinate;
                PreviousYCoordinate = textEditor.CurrentYCoordinate;

                this.TextEditor = textEditor;
            }
            public void Execute()
            {
                TextEditor.CurrentXCoordinate = XCoordinate;
                TextEditor.CurrentYCoordinate = YCoordinate;
            }

            public void Undo()
            {
                TextEditor.CurrentXCoordinate = PreviousXCoordinate;
                TextEditor.CurrentYCoordinate = PreviousYCoordinate;

                TextEditor.RedoOperations.Push(TextEditor.UndoOperations.Pop());
            }

            public void Redo()
            {
                TextEditor.RedoOperations.Peek().Execute();
                TextEditor.UndoOperations.Push(TextEditor.RedoOperations.Pop());
            }
        }
        public class InsertCharOperation : IOperation
        {
            private readonly char InsertingSymbol;
            private readonly TextEditor TextEditor;

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
                    TextEditor.Text[TextEditor.CurrentXCoordinate] = TextEditor.Text[TextEditor.CurrentXCoordinate].Insert(TextEditor.CurrentYCoordinate, InsertingSymbol.ToString());
                }
                TextEditor.CurrentYCoordinate++;
            }

            public void Undo()
            {
                TextEditor.Text[TextEditor.CurrentXCoordinate] = TextEditor.Text[TextEditor.CurrentXCoordinate].Remove(TextEditor.CurrentYCoordinate - 1, 1);
                TextEditor.CurrentYCoordinate--;
                TextEditor.RedoOperations.Push(TextEditor.UndoOperations.Pop());
            }

            public void Redo()
            {
                TextEditor.RedoOperations.Peek().Execute();
                TextEditor.UndoOperations.Push(TextEditor.RedoOperations.Pop());
            }
        }
        class DeleteCharOperation : IOperation
        {
            private readonly TextEditor TextEditor;
            private char DeletedSymbol;

            public DeleteCharOperation(TextEditor textEditor)
            {
                TextEditor = textEditor;
            }
            public void Execute()
            {
                if (TextEditor.Text.Count != 0)
                {
                    if (TextEditor.Text[TextEditor.CurrentXCoordinate].Length != 0)
                    {
                        DeletedSymbol = TextEditor.Text[TextEditor.CurrentXCoordinate][TextEditor.CurrentYCoordinate - 1];
                        TextEditor.Text[TextEditor.CurrentXCoordinate] = TextEditor.Text[TextEditor.CurrentXCoordinate].Remove(TextEditor.CurrentYCoordinate - 1, 1);
                        TextEditor.CurrentYCoordinate--;
                    }
                }
            }

            public void Undo()
            {
                TextEditor.RedoOperations.Push(TextEditor.UndoOperations.Pop());
                TextEditor.Text[TextEditor.CurrentXCoordinate] = TextEditor.Text[TextEditor.CurrentXCoordinate].Insert(TextEditor.CurrentYCoordinate, DeletedSymbol.ToString());
                TextEditor.CurrentYCoordinate++;
            }

            public void Redo()
            {
                TextEditor.RedoOperations.Peek().Execute();
                TextEditor.UndoOperations.Push(TextEditor.RedoOperations.Pop());
            }
        }
    }
}
