using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DynamicArrayTests
    {
        [Test]
        public void Initial()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));
            Assert.That(array.array[0], Is.EqualTo(0));
            Assert.That(array.array[15], Is.EqualTo(0));
        }

        [Test]
        public void GetItem()
        {
            var array = new DynArray<int>();
            array.Append(10);
            array.Append(11);
            array.Append(12);
            array.Append(13);

            Assert.That(array.count, Is.EqualTo(4));
            Assert.That(array.capacity, Is.EqualTo(16));

            try
            {
                Assert.That(array.GetItem(0), Is.EqualTo(10));
                Assert.That(array.GetItem(1), Is.EqualTo(11));
                Assert.That(array.GetItem(2), Is.EqualTo(12));
                Assert.That(array.GetItem(3), Is.EqualTo(13));
            }
            catch (System.Exception e)
            {
                Assert.Fail($"Test Failed with {e.GetType().Name}: {e.Message}");
            }
        }

        [Test]
        public void GetItemWhenEmptyArray()
        {
            var array = new DynArray<int>();
            try
            {
                array.GetItem(0);
                Assert.Fail($"Test Failed: There are should be IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is IndexOutOfRangeException);
            }
        }

        [Test]
        public void GetItemWhenIndexOutOfRange()
        {
            var array = new DynArray<int>();
            array.Append(10);
            array.Append(11);
            array.Append(12);
            array.Append(13);

            Assert.That(array.count, Is.EqualTo(4));
            Assert.That(array.capacity, Is.EqualTo(16));

            try
            {
                array.GetItem(4);
                Assert.Fail($"Test Failed: There are should be IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is IndexOutOfRangeException);
            }
        }

        [Test]
        public void AppendWithNotFullBuffer()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Append(10);
            array.Append(11);
            array.Append(12);
            array.Append(13);
            array.Append(14);
            array.Append(15);
            array.Append(16);
            array.Append(17);

            Assert.That(array.count, Is.EqualTo(8));
            Assert.That(array.capacity, Is.EqualTo(16));
        }

        [Test]
        public void AppendWithFullBuffer()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            for (int i = 1; i <= 16; i++)
            {
                array.Append(i);
            }
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Append(17);
            Assert.That(array.count, Is.EqualTo(17));
            Assert.That(array.capacity, Is.EqualTo(32));
        }

        [Test]
        public void InsertWithNotFullBuffer()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Append(10); // 0
            array.Append(11); // 1
            array.Append(12); // 2
            array.Append(14); // 3
            array.Append(15); // 4

            Assert.That(array.count, Is.EqualTo(5));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Insert(13, 3);
            Assert.That(array.count, Is.EqualTo(6));
            Assert.That(array.capacity, Is.EqualTo(16));

            Assert.That(array.GetItem(0), Is.EqualTo(10));
            Assert.That(array.GetItem(1), Is.EqualTo(11));
            Assert.That(array.GetItem(2), Is.EqualTo(12));
            Assert.That(array.GetItem(3), Is.EqualTo(13));
            Assert.That(array.GetItem(4), Is.EqualTo(14));
            Assert.That(array.GetItem(5), Is.EqualTo(15));

        }

        [Test]
        public void InsertWithFullBuffer()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            for (int i = 0; i <= 16; i++)
            {
                if (i == 7) continue;
                array.Append(i);
            }
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(16));

            for (int i = 0; i <= 15; i++)
            {
                if (i < 7) Assert.That(array.GetItem(i), Is.EqualTo(i));
                else Assert.That(array.GetItem(i), Is.EqualTo(i + 1));
            }

            array.Insert(7, 7);
            Assert.That(array.count, Is.EqualTo(17));
            Assert.That(array.capacity, Is.EqualTo(32));

            for (int i = 0; i <= 16; i++)
            {
                Assert.That(array.GetItem(i), Is.EqualTo(i));
            }

        }

        [Test]
        public void InsertToEnd()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Append(0);
            array.Append(1);
            array.Append(2);
            array.Append(3);
            Assert.That(array.count, Is.EqualTo(4));
            Assert.That(array.capacity, Is.EqualTo(16));

            try
            {
                var count = 4;
                array.Insert(count, count);
                for (int i = 0; i <= count; i++)
                    Assert.That(array.GetItem(i), Is.EqualTo(i));
            }
            catch (Exception e)
            {
                Assert.Fail($"Test Failed with {e.GetType().Name}: {e.Message}");
            }
        }

        [Test]
        public void InsertToEndWithFullBuffer()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            var count = 16;
            for (int i = 0; i < 16; i++)
            {
                array.Append(i);
            }
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Insert(count, count);
            Assert.That(array.count, Is.EqualTo(17));
            Assert.That(array.capacity, Is.EqualTo(32));

            for (int i = 0; i <= count; i++)
            {
                Assert.That(array.GetItem(i), Is.EqualTo(i));
            }

        }

        [Test]
        public void InsertToOutOfRange()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            var count = 16;
            for (int i = 0; i < count; i++)
            {
                array.Append(i);
            }
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(16));

            try
            {
                array.Insert(count, count + 1);
                Assert.Fail($"Test Failed: There are should be IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is IndexOutOfRangeException);
            }
        }

        [Test]
        public void RemoveWhenFullnessMoreOrEqualBoundOfFill()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            var count = 16;
            for (int i = 0; i < count; i++)
            {
                array.Append(i);
            }
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Append(count);
            Assert.That(array.count, Is.EqualTo(17));
            Assert.That(array.capacity, Is.EqualTo(32));

            array.Remove(0);
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(32));

            for (int i = 1; i <= count; i++)
            {
                Assert.That(array.GetItem(i - 1), Is.EqualTo(i));
            }
        }


        [Test]
        public void RemoveWhenFullnessLessBoundOfFill()
        {
            var array = new DynArray<int>();
            Assert.That(array.count, Is.EqualTo(0));
            Assert.That(array.capacity, Is.EqualTo(16));

            var count = 16;
            for (int i = 0; i < count; i++)
            {
                array.Append(i);
            }
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(16));

            array.Append(count);
            Assert.That(array.count, Is.EqualTo(17));
            Assert.That(array.capacity, Is.EqualTo(32));

            array.Remove(0);
            Assert.That(array.count, Is.EqualTo(16));
            Assert.That(array.capacity, Is.EqualTo(32));

            array.Remove(count - 1);
            Assert.That(array.count, Is.EqualTo(15));
            Assert.That(array.capacity, Is.EqualTo(21));

            for (int i = 0; i < count - 1; i++)
            {
                Assert.That(array.GetItem(i), Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void RemoveFromOutOfRange()
        {
            var array = new DynArray<int>();
            array.Append(10);
            array.Append(11);
            array.Append(12);
            array.Append(13);

            Assert.That(array.count, Is.EqualTo(4));
            Assert.That(array.capacity, Is.EqualTo(16));

            try
            {
                array.Remove(4);
                Assert.Fail($"Test Failed: There are should be IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is IndexOutOfRangeException);
            }
        }
    }
}
