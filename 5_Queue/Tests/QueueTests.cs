using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class QueueTests
    {
        public static IEnumerable<IQueue<int>> TestCases()
        {
            yield return new AlgorithmsDataStructures.Queue<int>();
            yield return new QueueWithLinkedList<int>();
            yield return new QueueWithTwoStacks<int>();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void EnqueueDequeue(IQueue<int> queue)
        {
            Assert.That(queue.Size(), Is.EqualTo(0));
            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
            }
            Assert.That(queue.Size(), Is.EqualTo(10));

            for (int i = 1; i <= 10; i++)
            {
                Assert.That(queue.Dequeue(), Is.EqualTo(i));
            }

            Assert.That(queue.Size(), Is.EqualTo(0));
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void DequeueWhenEmpty(IQueue<int> queue)
        {
            Assert.That(queue.Size(), Is.EqualTo(0));
            Assert.That(queue.Dequeue(), Is.EqualTo(0));
            Assert.That(queue.Size(), Is.EqualTo(0));
        }


        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void QueueRotatorTest(IQueue<int> queue)
        {
            Assert.That(queue.Size(), Is.EqualTo(0));
            for (int i = 1; i <= 5; i++)
                queue.Enqueue(i);
            Assert.That(queue.Size(), Is.EqualTo(5));

            QueueRotator.Rotate(1, queue);
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.Dequeue(), Is.EqualTo(1));

            for (int i = 1; i <= 5; i++)
                queue.Enqueue(i);

            QueueRotator.Rotate(2, queue);
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));

            for (int i = 1; i <= 5; i++)
                queue.Enqueue(i);

            QueueRotator.Rotate(3, queue);
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));

            for (int i = 1; i <= 5; i++)
                queue.Enqueue(i);

            QueueRotator.Rotate(4, queue);
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));

            for (int i = 1; i <= 5; i++)
                queue.Enqueue(i);

            QueueRotator.Rotate(5, queue);
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));

        }
    }
}
