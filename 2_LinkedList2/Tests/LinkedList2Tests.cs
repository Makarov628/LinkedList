using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LinkedList2Tests
    {
        private static List<int> ToArray(LinkedList2 list)
        {
            List<int> intList = new List<int>();
            Node item = list.head;
            while (item != null)
            {
                intList.Add(item.value);
                item = item.next;
            }
            return intList;
        }

        private static List<int> ToArrayReverse(LinkedList2 list)
        {
            List<int> intList = new List<int>();
            Node item = list.tail;
            while (item != null)
            {
                intList.Add(item.value);
                item = item.prev;
            }
            return intList;
        }

        LinkedList2 list = new LinkedList2();
        Node n1 = new Node(12);
        Node n2 = new Node(55);
        Node n3 = new Node(28);
        Node n4 = new Node(12);
        Node n5 = new Node(13);
        Node n6 = new Node(55);

        [Test]
        public void FindTest_True()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            Assert.AreEqual(n5, list.Find(13));
        }

        [Test]
        public void FindTest_False()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            Assert.IsNull(list.Find(152));
        }

        [Test]
        public void FindTest_EmptyList()
        {
            Assert.IsNull(list.Find(152));
        }

        [Test]
        public void FindAllTest_True()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            List<Node> nodes = new List<Node> { n1, n4 };
            Assert.AreEqual(nodes, list.FindAll(12));
        }

        [Test]
        public void FindAllTest_False()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            List<Node> nodes = new List<Node>();
            Assert.AreEqual(nodes, list.FindAll(152));
        }

        [Test]
        public void FindAllTest_Empty()
        {
            List<Node> nodes = new List<Node>();
            Assert.AreEqual(nodes, list.FindAll(152));
        }

        [Test]
        public void RemoveTest_One()
        {
            list.AddInTail(n1);
            Assert.IsTrue(list.Remove(12));
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveTest_OnlyHead()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            Assert.IsTrue(list.Remove(12));
            Assert.AreEqual(n2, list.head);
            Assert.AreEqual(n2, list.tail);
        }

        [Test]
        public void RemoveTest_OnlyTail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            Assert.IsTrue(list.Remove(55));
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n1, list.tail);
            Assert.IsNull(n1.prev);
            Assert.IsNull(n1.next);
        }

        [Test]
        public void RemoveTest_Middle()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            Assert.IsTrue(list.Remove(55));
            List<int> array = new List<int> { 12, 28 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 28, 12 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void RemoveTest_False()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            Assert.IsFalse(list.Remove(152));
        }

        [Test]
        public void RemoveTest_Regression()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            Assert.IsTrue(list.Remove(13));
            List<int> array = new List<int> { 12, 55, 28, 12, 55 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 55, 12, 28, 55, 12 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void RemoveTest_Empty()
        {
            Assert.IsFalse(list.Remove(13));
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveAllTest_AllTrue()
        {
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(12));
            list.RemoveAll(12);
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveAll_RemoveOnlyHead()
        {
            list.AddInTail(new Node(10));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(13));
            list.RemoveAll(10);
            List<int> array = new List<int> { 11, 12, 13 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 13, 12, 11 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void RemoveAll_RemoveOnlyTail()
        {
            list.AddInTail(new Node(10));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(13));
            list.RemoveAll(13);
            List<int> array = new List<int> { 10, 11, 12 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 12, 11, 10 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void RemoveAll_LeaveOnlyHead()
        {
            list.AddInTail(new Node(10));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(11));
            list.RemoveAll(11);
            Assert.AreEqual(list.head, list.tail);
        }

        [Test]
        public void RemoveAll_LeaveOnlyTail()
        {
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(10));
            list.RemoveAll(11);
            Assert.AreEqual(list.head, list.tail);
        }

        [Test]
        public void RemoveAll_Body()
        {
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(10));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(10));
            list.AddInTail(new Node(13));
            list.RemoveAll(10);
            List<int> array = new List<int> { 11, 12, 13 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 13, 12, 11 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void RemoveAll_NoMatch()
        {
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(13));
            list.RemoveAll(15);
            List<int> array = new List<int> { 11, 12, 13 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 13, 12, 11 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void ClearTest()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n6, list.tail);
            list.Clear();
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void CountTest_Many()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            Assert.AreEqual(6, list.Count());
        }

        [Test]
        public void CountTest_One()
        {
            list.AddInTail(n1);
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void CountTest_Empty()
        {
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void InsertAfterTest_Head()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(n1, n5);
            List<int> array = new List<int> { 12, 13, 55, 28, 12 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 12, 28, 55, 13, 12 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void InsertAfterTest_Tail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(n4, n5);
            List<int> array = new List<int> { 12, 55, 28, 12, 13 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 13, 12, 28, 55, 12 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void InsertAfterTest_Body()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(n3, n5);
            List<int> array = new List<int> { 12, 55, 28, 13, 12 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 12, 13, 28, 55, 12 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void InsertAfterTest_NullWithEmptyList()
        {
            list.InsertAfter(null, n5);
            Assert.AreEqual(n5, list.head);
            Assert.AreEqual(list.head, list.tail);
        }

        [Test]
        public void InsertAfterTest_NullWithNoEmptyList()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.InsertAfter(null, n5);
            List<int> array = new List<int> { 13, 12, 55, 28 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 28, 55, 12, 13 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }

        [Test]
        public void InsertAfterTest_NoMatch()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.InsertAfter(n4, n5);
            List<int> array = new List<int> { 12, 55, 28 };
            Assert.AreEqual(array, ToArray(list));
            array.Clear();
            array.AddRange(new List<int> { 28, 55, 12 });
            Assert.AreEqual(array, ToArrayReverse(list));
        }
    }
}
