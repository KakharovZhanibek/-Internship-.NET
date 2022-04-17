// See https://aka.ms/new-console-template for more information

namespace ParallelTreeTraverse
{
    public class Program
    {
        static void Main()
        {
            Tree<int> intTree = new Tree<int>() { Data = 39 };

            intTree.Left = new Tree<int>() { Data = 35 };
            intTree.Right = new Tree<int>() { Data = 44 };

            intTree.Left.Left = new Tree<int>() { Data = 33 };
            intTree.Left.Right = new Tree<int>() { Data = 37 };

            intTree.Right.Left = new Tree<int>() { Data = 40 };
            intTree.Right.Right = new Tree<int>() { Data = 47 };

            Action<int> action = x => Console.WriteLine(x);

            DoTree<int>(intTree, action);
        }
        public class Tree<T>
        {
            public Tree<T> Left;
            public Tree<T> Right;
            public T Data;
        }

        static void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;
            var left = Task.Factory.StartNew(() => DoTree(tree.Left, action));
            var right = Task.Factory.StartNew(() => DoTree(tree.Right, action));
            action(tree.Data);

            try
            {
                Task.WaitAll(left, right);
            }
            catch (AggregateException)
            {

            }
        }
    }
}
