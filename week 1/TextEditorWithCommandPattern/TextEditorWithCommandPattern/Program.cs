using System;

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

            foreach (string stringString in textEditor.Text)
            {
                Console.WriteLine(stringString);
            }
            Console.WriteLine(" focus  "+textEditor.Text[5][19]);

            textEditor.DeleteChar();

            foreach (string stringString in textEditor.Text)
            {
                Console.WriteLine(stringString);
            }
        }
    }
}
