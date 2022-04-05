using IDisposable_exercises.Classes;
using System;

namespace IDisposable_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();

            customer.Dispose();
        }
    }
}
