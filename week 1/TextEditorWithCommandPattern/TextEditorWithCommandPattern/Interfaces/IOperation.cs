using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorWithCommandPattern.Interfaces
{
    interface IOperation
    {
        void Execute();
        void Undo();
        void Redo();
    }
}
