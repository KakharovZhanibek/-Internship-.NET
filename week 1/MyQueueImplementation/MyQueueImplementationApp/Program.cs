using MyQueueImplementation.Classes;
using System;

namespace MyQueueImplementationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<string> stringMyQueue = new MyQueue<string>();

            MyQueue<int> intMyQueue = new MyQueue<int>();

            stringMyQueue.Enqueue("sretjsertj");
            stringMyQueue.Enqueue("tdyjtykyuggf");

            intMyQueue.Enqueue(777);
            intMyQueue.Enqueue(666);

            Console.WriteLine(stringMyQueue.Dequeue());
            Console.WriteLine(stringMyQueue.Peek());


            Console.WriteLine("\n"+intMyQueue.Dequeue());
            Console.WriteLine(intMyQueue.Peek());
        }
    }
}
