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

            Action<int> action = new Action<int>((a)=> Console.WriteLine(a));

            DoTree<int>(intTree, action);
        }
        public class Tree<T>
        {
            public Tree<T>? Left;
            public Tree<T>? Right;
            public T Data;
        }

        static void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null)
                return;

            action(tree.Data);

            var left = Task.Factory.StartNew(() => DoTree(tree.Left, action));
            var right = Task.Factory.StartNew(() => DoTree(tree.Right, action));

            try
            {
                Task.WaitAll(left, right);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(left.Status);
                Console.WriteLine(right.Status);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
