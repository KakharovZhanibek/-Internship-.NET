using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorWithCommandPattern.Interfaces;

namespace TextEditorWithCommandPattern.Classes
{
    class OperationManager
    {
        public static OperationManager Instance;
        static OperationManager() => Instance = new OperationManager();

        private Stack<IOperation> Operations;
        public OperationManager() => Operations = new Stack<IOperation>();

        public void AddOperation(IOperation operation) => Operations.Push(operation);

        public void ProccessOperations()
        {
            Operations.Where(operation => !operation.IsComplete)
                      .ToList()
                      .ForEach(operation => operation.Execute());
        }
    }
}
