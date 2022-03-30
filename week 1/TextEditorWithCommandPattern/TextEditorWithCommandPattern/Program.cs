using System;
using TextEditorWithCommandPattern.Classes;

namespace TextEditorWithCommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            textEditor.MoveCursorTo(2, 9);
            textEditor.InsertChar('F');
            textEditor.MoveCursorTo(3, 12);
            textEditor.InsertChar('i');
            textEditor.MoveCursorTo(4, 15);
            textEditor.InsertChar('n');
            textEditor.MoveCursorTo(5, 18);
            textEditor.InsertChar('e');
            textEditor.InsertChar('!');

            textEditor.InsertChar('H');
            textEditor.InsertChar('e');
            textEditor.InsertChar('l');
            textEditor.InsertChar('l');
            textEditor.InsertChar('o');
            textEditor.InsertChar(' ');
            textEditor.InsertChar('W');
            textEditor.InsertChar('o');
            textEditor.InsertChar('r');
            textEditor.InsertChar('l');
            textEditor.InsertChar('d');
            textEditor.InsertChar('!');

            foreach (string stringString in textEditor.Text)
            {
                Console.WriteLine(stringString);
            }

            textEditor.Undo();
            textEditor.Undo();
            textEditor.Undo();

            foreach (string stringString in textEditor.Text)
            {
                Console.WriteLine(stringString);
            }
            textEditor.InsertChar('d');
            textEditor.InsertChar('!');

            textEditor.Redo();
            textEditor.Redo();
            textEditor.Redo();
            foreach (string stringString in textEditor.Text)
            {
                Console.WriteLine(stringString);
            }

            textEditor.Undo();
            textEditor.Undo();
            textEditor.Undo();
            // textEditor.InsertChar('!');
            foreach (string stringString in textEditor.Text)
            {
                Console.WriteLine(stringString);
            }
        }
    }
}
