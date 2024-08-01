using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MultiTypeStackTests
    {
        [Test]
        public void SizeEmpty()
        {
            var stack = new MultiTypeStack();
            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Size()
        {
            var stack = new MultiTypeStack();
            stack.Push(5);
            stack.Push(5.0);
            stack.Push("five");
            Assert.That(stack.Size(), Is.EqualTo(3));
        }

        [Test]
        public void PopMultipleTypes()
        {
            var stack = new MultiTypeStack();
            stack.Push(5);
            stack.Push(5.0);
            stack.Push("five");
            Assert.That(stack.Size(), Is.EqualTo(3));

            Assert.That(stack.Pop<string>().GetValue(), Is.EqualTo("five"));
            Assert.That(stack.Pop<double>().GetValue(), Is.EqualTo(5.0));
            Assert.That(stack.Pop<int>().GetValue(), Is.EqualTo(5));

            Assert.That(stack.Pop<int>().Status, Is.EqualTo(StackExtractStatus.StackIsEmpty));
            Assert.That(stack.Peek<int>().Status, Is.EqualTo(StackExtractStatus.StackIsEmpty));
            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void PopWrongType()
        {
            var stack = new MultiTypeStack();
            stack.Push(5);
            stack.Push(5.0);
            stack.Push("five");
            Assert.That(stack.Size(), Is.EqualTo(3));

            Assert.That(stack.Peek<bool>().IsSuccess, Is.EqualTo(false));
            Assert.That(stack.Pop<bool>().Status, Is.EqualTo(StackExtractStatus.TypesDidNotMatch));
            Assert.Throws(typeof(TypeAccessException), () => { stack.Peek<bool>().GetValue(); });

            Assert.That(stack.Peek<int>().IsSuccess, Is.EqualTo(false));
            Assert.That(stack.Pop<int>().Status, Is.EqualTo(StackExtractStatus.TypesDidNotMatch));
            Assert.Throws(typeof(TypeAccessException), () => { stack.Peek<int>().GetValue(); });

            Assert.That(stack.Peek<double>().IsSuccess, Is.EqualTo(false));
            Assert.That(stack.Pop<double>().Status, Is.EqualTo(StackExtractStatus.TypesDidNotMatch));
            Assert.Throws(typeof(TypeAccessException), () => { stack.Peek<double>().GetValue(); });

            Assert.That(stack.Pop<string>().Status, Is.EqualTo(StackExtractStatus.Success));
            Assert.That(stack.Pop<double>().Status, Is.EqualTo(StackExtractStatus.Success));
            Assert.That(stack.Pop<int>().Status, Is.EqualTo(StackExtractStatus.Success));

            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Push()
        {
            var stack = new MultiTypeStack();
            stack.Push(5);
            stack.Push(5.0);
            stack.Push("five");
            Assert.That(stack.Size(), Is.EqualTo(3));

            Assert.That(stack.Pop<string>().GetValue(), Is.EqualTo("five"));
            Assert.That(stack.Pop<double>().GetValue(), Is.EqualTo(5.0));
            Assert.That(stack.Pop<int>().GetValue(), Is.EqualTo(5));

            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Peek()
        {
            var stack = new MultiTypeStack();
            stack.Push("five");
            Assert.That(stack.Size(), Is.EqualTo(1));

            Assert.That(stack.Peek<int>().IsSuccess, Is.EqualTo(false));
            Assert.That(stack.Peek<int>().Status, Is.EqualTo(StackExtractStatus.TypesDidNotMatch));
            Assert.Throws(typeof(TypeAccessException), () => { stack.Peek<int>().GetValue(); });

            Assert.That(stack.Peek<string>().GetValue(), Is.EqualTo("five"));
            Assert.That(stack.Size(), Is.EqualTo(1));

            stack.Pop<string>();
            Assert.Throws(typeof(NullReferenceException), () => stack.Peek<string>().GetValue());
        }


    }
}
