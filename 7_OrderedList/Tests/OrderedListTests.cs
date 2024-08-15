using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class OrderedListTests
    {
        public List<T> ToListOfValues<T>(OrderedList<T> list) =>
            list.GetAll().Select(node => node.value).ToList();

        [Test]
        public void CompareTest()
        {
            OrderedList<int> listInt = new OrderedList<int>(false);
            Assert.That(listInt.Compare(3, 3), Is.EqualTo(0));
            Assert.That(listInt.Compare(3, 2), Is.EqualTo(1));
            Assert.That(listInt.Compare(5, 6), Is.EqualTo(-1));

            OrderedList<string> listString = new OrderedList<string>(false);
            Assert.That(listString.Compare("abc", "ab"), Is.EqualTo(1));
            Assert.That(listString.Compare(" abc ", "ab"), Is.EqualTo(1));
            Assert.That(listString.Compare("a", " aaa "), Is.EqualTo(-1));
            Assert.That(listString.Compare("abc", "abc"), Is.EqualTo(0));
        }

        [Test]
        public void AddDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(1);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(3);

            List<int> numbers = new List<int> { 5, 4, 3, 3, 2, 1 };
            Assert.That(ToListOfValues(list), Is.Ordered.Descending);
        }

        [Test]
        public void AddAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(1);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 5 };
            Assert.That(ToListOfValues(list), Is.Ordered.Ascending);
        }

        [Test]
        public void FindEmptyNull()
        {
            OrderedList<int> list1 = new OrderedList<int>(true);
            OrderedList<int> list2 = new OrderedList<int>(false);
            Assert.IsNull(list1.Find(1));
            Assert.IsNull(list2.Find(1));
        }

        [Test]
        public void FindNullSmallerAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);
            Assert.IsNull(list.Find(1));
        }

        [Test]
        public void FindNullBiggerAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);
            Assert.IsNull(list.Find(6));
        }

        [Test]
        public void FindAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);
            Assert.That(list.Find(3).value, Is.EqualTo(3));
        }

        [Test]
        public void FindNullSmallerDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);
            Assert.IsNull(list.Find(1));
        }

        [Test]
        public void FindNullBiggerDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);
            Assert.IsNull(list.Find(6));
        }

        [Test]
        public void FindDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(4);
            list.Add(5);
            list.Add(3);
            list.Add(2);
            Assert.That(list.Find(3)?.value, Is.EqualTo(3));
        }

        [Test]
        public void RemoveTwoAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);

            list.Delete(3);
            Assert.That(list.Count(), Is.EqualTo(1));
            Assert.That(list.head.value, Is.EqualTo(5));
        }

        [Test]
        public void RemoveTwoDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(3);

            list.Delete(5);
            Assert.That(list.Count(), Is.EqualTo(1));
            Assert.That(list.head.value, Is.EqualTo(3));
        }

        [Test]
        public void RemoveOneToEmpty()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);

            list.Delete(5);
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveEmpty()
        {
            OrderedList<int> list1 = new OrderedList<int>(true);
            OrderedList<int> list2 = new OrderedList<int>(false);
            list1.Delete(5);
            list2.Delete(5);
            Assert.That(list1.Count(), Is.EqualTo(0));
            Assert.That(list2.Count(), Is.EqualTo(0));
        }

        [Test]
        public void RemoveSmallerNullAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(1);
            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        public void RemoveBiggerNullAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(6);
            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        public void RemoveHeadAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(2);
            Assert.That(list.Count(), Is.EqualTo(2));

            List<int> numbers = new List<int> { 3, 5 };
            Assert.That(ToListOfValues(list), Is.Ordered.Ascending);
        }

        [Test]
        public void RemoveTailAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(5);
            Assert.That(list.Count(), Is.EqualTo(2));

            List<int> numbers = new List<int> { 2, 3 };
            Assert.That(ToListOfValues(list), Is.Ordered.Ascending);
        }

        [Test]
        public void RemoveBodyAscending()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);
            list.Add(3);
            list.Add(2);

            list.Delete(3);
            Assert.That(list.Count(), Is.EqualTo(3));

            List<int> numbers = new List<int> { 2, 3, 5 };
            Assert.That(ToListOfValues(list), Is.Ordered.Ascending);
        }

        [Test]
        public void RemoveSmallerNullDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(1);
            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        public void RemoveBiggerNullDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(6);
            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        public void RemoveHeadDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(1);
            list.Add(3);
            list.Add(2);

            list.Delete(5);
            Assert.That(list.Count(), Is.EqualTo(3));

            List<int> numbers = new List<int> { 3, 2, 1 };
            Assert.That(ToListOfValues(list), Is.Ordered.Descending);
        }

        [Test]
        public void RemoveTailDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(3);
            list.Add(2);

            list.Delete(2);
            Assert.That(list.Count(), Is.EqualTo(2));

            List<int> numbers = new List<int> { 5, 3 };
            Assert.That(ToListOfValues(list), Is.Ordered.Descending);
        }

        [Test]
        public void RemoveBodyDescending()
        {
            OrderedList<int> list = new OrderedList<int>(false);
            list.Add(5);
            list.Add(3);
            list.Add(3);
            list.Add(2);

            list.Delete(3);
            Assert.That(list.Count(), Is.EqualTo(3));

            List<int> numbers = new List<int> { 5, 3, 2 };
            Assert.That(ToListOfValues(list), Is.Ordered.Descending);
        }

        [Test]
        public void ClearTest()
        {
            OrderedList<int> list = new OrderedList<int>(true);
            list.Add(5);
            list.Add(3);
            list.Add(3);
            list.Add(2);

            List<int> numbers = new List<int> { 2, 3, 3, 5 };
            Assert.That(ToListOfValues(list), Is.Ordered.Ascending);
            
            list.Clear(false);
            list.Add(5);
            list.Add(3);
            list.Add(3);
            list.Add(2);
            
            numbers.Clear();
            numbers.Add(5);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(2);
            
            Assert.That(ToListOfValues(list), Is.Ordered.Descending);
        }
    }
}
