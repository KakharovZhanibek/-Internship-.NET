using MyQueueImplementation.Classes;
using System;
using Xunit;

namespace MyQueueImplementation.Tests
{
    public class MyQueueTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            MyQueue<string> myQueue = new MyQueue<string>();
            myQueue.Enqueue("TEST STRING");
            var expected = "TEST STRING";
            var count = 1;
            //Act
            var actual = myQueue.Peek();

            //assert
            Assert.Equal(expected,actual);
            Assert.Equal(count, myQueue.Count);
        }
        [Fact]
        public void Test2()
        {
            //Arrange
            MyQueue<string> myQueue = new MyQueue<string>();
            myQueue.Enqueue("TEST STRING");
            var expected = "TEST STRING";

            //Act
            var actual = myQueue.Dequeue();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
