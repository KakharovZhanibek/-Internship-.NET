using MyQueueImplementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyQueueImplementation.Classes
{
    public class MyQueue<T> : IQueue<T>
    {
        List<T> _items = new List<T>();
        public int Count = 0;
        public T Dequeue()
        {
            var item = GetItem();

            _items.Remove(item);
            Count--;
            return item;
        }

        public void Enqueue(T item)
        {
            if (item == null)
                throw new NullReferenceException();

            _items.Add(item);
            Count++;
        }

        public T Peek()
        {
            var item = GetItem();

            return item;
        }
        private T GetItem()
        {
            var item = _items.FirstOrDefault();

            if (item == null)
                throw new NullReferenceException();

            return item;
        }
    }
}
