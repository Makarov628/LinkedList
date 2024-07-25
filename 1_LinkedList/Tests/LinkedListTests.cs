using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        LinkedList list = new LinkedList();
        Node n1 = new Node(12);
        Node n2 = new Node(55);
        Node n3 = new Node(28);
        Node n4 = new Node(12);
        Node n5 = new Node(13);
        Node n6 = new Node(55);
        Node n7 = new Node(28);

        [Test]
        public void FindAllTest_3items_0matchArray()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            List<Node> nodes = new List<Node>();
            Assert.AreEqual(nodes, list.FindAll(58));
        }

        [Test]
        public void FindAllTest_0items_0matchArray()
        {
            List<Node> nodes = new List<Node>();
            Assert.AreEqual(nodes, list.FindAll(12));
        }

        [Test]
        public void FindAllTest_7items_2matchArrayheadAndBody()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            list.AddInTail(n7);
            List<Node> nodes = new List<Node> { n1, n4 };
            Assert.AreEqual(nodes, list.FindAll(12));
        }

        [Test]
        public void FindAllTest_7items_2matchArrayBodyAndtail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            list.AddInTail(n7);
            List<Node> nodes = new List<Node> { n3, n7 };
            Assert.AreEqual(nodes, list.FindAll(28));
        }

        [Test]
        public void FindAllTest_7items_1matchArray()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            list.AddInTail(n7);
            List<Node> nodes = new List<Node> { n5 };
            Assert.AreEqual(nodes, list.FindAll(13));
        }

        [Test]
        public void Count_Empty()
        {
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void Count_One()
        {
            list.AddInTail(n1);
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void Count_Many()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void Clear()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n3, list.tail);
            list.Clear();
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void Remove_Empty()
        {
            Assert.IsFalse(list.Remove(52));
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void Remove_1item_True()
        {
            list.AddInTail(n1);
            Assert.IsTrue(list.Remove(12));
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void Remove_1item_False()
        {
            list.AddInTail(n2);
            Assert.IsFalse(list.Remove(12));
            Assert.AreEqual(n2, list.head);
            Assert.AreEqual(n2, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void Remove_3items_True_head()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n4);
            Assert.IsTrue(list.Remove(12));
            Assert.AreEqual(n2, list.head);
            Assert.AreEqual(n4, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void Remove_3items_True_tail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            Assert.IsTrue(list.Remove(28));
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n2, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void Remove_3items_True_Body()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            Assert.IsTrue(list.Remove(55));
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n3, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void Remove_2items_True_head()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            Assert.IsTrue(list.Remove(12));
            Assert.AreEqual(n2, list.head);
            Assert.AreEqual(n2, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void Remove_2items_True_tail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            Assert.IsTrue(list.Remove(55));
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n1, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void Remove_3items_False()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n4);
            Assert.IsFalse(list.Remove(49));
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n4, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_Empty()
        {
            list.RemoveAll(12);
            Assert.AreEqual(0, list.Count());
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveAll_All()
        {
            list.AddInTail(n1);
            list.AddInTail(n4);
            list.RemoveAll(12);
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveAll_2items()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            list.AddInTail(n7);
            list.RemoveAll(12);
            Assert.AreEqual(5, list.Count());
            Assert.AreEqual(n2, list.head);
            Assert.AreEqual(n7, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_7itemsAll()
        {
            list.AddInTail(n1);
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(12));
            list.AddInTail(n4);
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(12));
            list.RemoveAll(12);
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void RemoveAll_7itemsOneBody()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n5);
            list.AddInTail(n6);
            list.AddInTail(n7);
            list.RemoveAll(13);
            Assert.AreEqual(6, list.Count());
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n7, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_7itemsheadBody()
        {
            list.AddInTail(n1);
            list.AddInTail(new Node(46));
            list.AddInTail(new Node(46));
            list.AddInTail(new Node(46));
            list.AddInTail(new Node(46));
            list.AddInTail(new Node(46));
            list.AddInTail(n7);
            list.RemoveAll(46);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n7, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_2items_tail()
        {
            list.AddInTail(n1);
            list.AddInTail(n4);
            list.AddInTail(n3);
            list.RemoveAll(12);
            Assert.AreEqual(n3, list.head);
            Assert.AreEqual(n3, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_2items_head()
        {
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.AddInTail(n1);
            list.RemoveAll(12);
            Assert.AreEqual(n3, list.head);
            Assert.AreEqual(n3, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_head()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.RemoveAll(12);
            Assert.AreEqual(n2, list.head);
            Assert.AreEqual(n2, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void RemoveAll_tail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.RemoveAll(55);
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n1, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void InsertAfter_Regression()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(n3, n5);
            Assert.AreEqual(5, list.Count());
            Node node = list.head;
            int counter = 0;
            while (counter < 3)
            {
                node = node.next;
                counter++;
            }
            Assert.AreEqual(n5, node);
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n4, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void InsertAfter_tail()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(n4, n5);
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n5, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void InsertAfter_NoMatch()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(n6, n5);
            Assert.AreEqual(4, list.Count());
            Assert.AreEqual(n1, list.head);
            Assert.AreEqual(n4, list.tail);
        }

        [Test]
        public void InsertAfter_Empty()
        {
            list.InsertAfter(n3, n5);
            Assert.AreEqual(0, list.Count());
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [Test]
        public void InsertAfter_Null_Empty()
        {
            list.InsertAfter(null, n5);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(n5, list.head);
            Assert.AreEqual(n5, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void InsertAfter_Regression_Null()
        {
            list.AddInTail(n1);
            list.AddInTail(n2);
            list.AddInTail(n3);
            list.AddInTail(n4);
            list.InsertAfter(null, n5);
            Assert.AreEqual(5, list.Count());
            Assert.AreEqual(n5, list.head);
            Assert.AreEqual(n4, list.tail);
            Assert.IsNull(list.tail.next);
        }

        [Test]
        public void SumOfTwoTest_True()
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            List<int> expected = new List<int> { 24, 49, 172 };
            list1.AddInTail(new Node(12));
            list1.AddInTail(new Node(13));
            list1.AddInTail(new Node(35));
            list2.AddInTail(new Node(12));
            list2.AddInTail(new Node(36));
            list2.AddInTail(new Node(137));
            Assert.AreEqual(expected, LinkedList.Sum(list1, list2));
        }

        [Test]
        public void SumOfTwoTest_False()
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            List<int> expected = new List<int>();
            list1.AddInTail(new Node(12));
            list1.AddInTail(new Node(13));
            list1.AddInTail(new Node(35));
            list2.AddInTail(new Node(12));
            list2.AddInTail(new Node(36));
            Assert.AreEqual(expected, LinkedList.Sum(list1, list2));
        }

        [Test]
        public void SumOfTwoTest_Empty()
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            List<int> expected = new List<int>();
            Assert.AreEqual(expected, LinkedList.Sum(list1, list2));
        }
    }
}
