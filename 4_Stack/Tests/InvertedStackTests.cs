using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InvertedStackTests
    {
        [Test]
        public void SizeEmpty()
        {
            var stack = new InvertedStack<int>();
            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Size()
        {
            var stack = new InvertedStack<int>();
            stack.Push(5);
            stack.Push(1);
            Assert.That(stack.Size(), Is.EqualTo(2));
        }

        [Test]
        public void Pop()
        {
            var stack = new InvertedStack<int>();
            stack.Push(5);
            stack.Push(1);
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(5));
            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void PopNullForInt()
        {
            var stack = new InvertedStack<int>();
            stack.Push(5);
            stack.Push(1);
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(5));
            Assert.That(stack.Size(), Is.EqualTo(0));

            Assert.That(stack.Pop(), Is.EqualTo(0));
        }

        [Test]
        public void PopNullForDouble()
        {
            var stack = new InvertedStack<double>();
            stack.Push(5.0);
            stack.Push(1.0);
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(5));
            Assert.That(stack.Size(), Is.EqualTo(0));

            Assert.That(stack.Pop(), Is.EqualTo(0));
        }

        [Test]
        public void PopNullForChar()
        {
            var stack = new Stack<char>();
            stack.Push('5');
            stack.Push('1');
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo('1'));
            Assert.That(stack.Pop(), Is.EqualTo('5'));
            Assert.That(stack.Size(), Is.EqualTo(0));

            Assert.That(stack.Pop(), Is.EqualTo(char.MinValue));
        }

        [Test]
        public void PopNullForString()
        {
            var stack = new InvertedStack<string>();
            stack.Push("five");
            stack.Push("one");
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo("one"));
            Assert.That(stack.Pop(), Is.EqualTo("five"));
            Assert.That(stack.Size(), Is.EqualTo(0));

            Assert.That(stack.Pop(), Is.EqualTo(null));
        }

        [Test]
        public void PopNullForBool()
        {
            var stack = new InvertedStack<bool>();
            stack.Push(false);
            stack.Push(true);
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(true));
            Assert.That(stack.Pop(), Is.EqualTo(false));
            Assert.That(stack.Size(), Is.EqualTo(0));

            Assert.That(stack.Pop(), Is.EqualTo(false));
        }

        [Test]
        public void Push()
        {
            var stack = new InvertedStack<int>();
            stack.Push(5);
            stack.Push(1);
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(5));
        }

        [Test]
        public void Peek()
        {
            var stack = new InvertedStack<int>();
            stack.Push(5);
            stack.Push(1);
            Assert.That(stack.Size(), Is.EqualTo(2));
            Assert.That(stack.Peek(), Is.EqualTo(1));
            Assert.That(stack.Size(), Is.EqualTo(2));
        }

    }
}
