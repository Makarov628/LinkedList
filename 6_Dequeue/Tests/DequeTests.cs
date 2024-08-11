using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DequeTests
    {

        [Test]
        public void AddFront()
        {
            var deque = new Deque<int>();
            Assert.That(deque.Size(), Is.EqualTo(0));

            for (int i = 1; i <= 10; i++)
                deque.AddFront(i);

            Assert.That(deque.Size(), Is.EqualTo(10));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(10));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(1));

            deque.AddFront(11);

            Assert.That(deque.Size(), Is.EqualTo(11));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(11));
            Assert.That(deque.linkedList.First.Next.Value, Is.EqualTo(10));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(1));
        }

        [Test]
        public void AddTail()
        {
            var deque = new Deque<int>();
            Assert.That(deque.Size(), Is.EqualTo(0));

            for (int i = 1; i <= 10; i++)
                deque.AddTail(i);

            Assert.That(deque.Size(), Is.EqualTo(10));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(1));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(10));

            deque.AddTail(11);

            Assert.That(deque.Size(), Is.EqualTo(11));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(1));
            Assert.That(deque.linkedList.Last.Previous.Value, Is.EqualTo(10));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(11));
        }

        [Test]
        public void RemoveFront()
        {
            var deque = new Deque<int>();
            Assert.That(deque.Size(), Is.EqualTo(0));

            for (int i = 1; i <= 10; i++)
                deque.AddTail(i);

            Assert.That(deque.Size(), Is.EqualTo(10));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(1));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(10));

            Assert.That(deque.RemoveFront(), Is.EqualTo(1));

            Assert.That(deque.Size(), Is.EqualTo(9));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(2));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(10));

        }

        [Test]
        public void RemoveTail()
        {
            var deque = new Deque<int>();
            Assert.That(deque.Size(), Is.EqualTo(0));

            for (int i = 1; i <= 10; i++)
                deque.AddTail(i);

            Assert.That(deque.Size(), Is.EqualTo(10));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(1));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(10));

            Assert.That(deque.RemoveTail(), Is.EqualTo(10));

            Assert.That(deque.Size(), Is.EqualTo(9));
            Assert.That(deque.linkedList.First.Value, Is.EqualTo(1));
            Assert.That(deque.linkedList.Last.Value, Is.EqualTo(9));
        }

        [Test]
        public void TestAsStack()
        {
            var dequeAsStack = new Deque<int>();
            Assert.That(dequeAsStack.Size(), Is.EqualTo(0));

            for (int i = 1; i <= 10; i++)
                dequeAsStack.AddFront(i);

            Assert.That(dequeAsStack.Size(), Is.EqualTo(10));

            for (int i = 10; i >= 1; i--)
                Assert.That(dequeAsStack.RemoveFront(), Is.EqualTo(i));

            Assert.That(dequeAsStack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void TestAsQueue()
        {
            var dequeAsQueue = new Deque<int>();
            Assert.That(dequeAsQueue.Size(), Is.EqualTo(0));

            for (int i = 1; i <= 10; i++)
                dequeAsQueue.AddTail(i);

            Assert.That(dequeAsQueue.Size(), Is.EqualTo(10));

            for (int i = 1; i <= 10; i++)
                Assert.That(dequeAsQueue.RemoveFront(), Is.EqualTo(i));

            Assert.That(dequeAsQueue.Size(), Is.EqualTo(0));
        }

        [Test]
        public void DequeueWhenEmpty()
        {
            var deque = new Deque<int>();
            Assert.That(deque.Size(), Is.EqualTo(0));

            deque.RemoveFront();
            Assert.That(deque.Size(), Is.EqualTo(0));

            deque.RemoveTail();
            Assert.That(deque.Size(), Is.EqualTo(0));
        }


        [Test]
        public void StringIsPalindrome()
        {
            var str = "TENET";
            Assert.IsTrue(Palindrome.IsPalindrome(str));

            var str2 = "ABBA";
            Assert.IsTrue(Palindrome.IsPalindrome(str2));
        }

        [Test]
        public void StringIsNotPalindrome()
        {
            var str = "SATOR";
            Assert.IsFalse(Palindrome.IsPalindrome(str));

            var str1 = "I've see things what you people wouldn't believe.";
            Assert.IsFalse(Palindrome.IsPalindrome(str1));
        }
    }
}
