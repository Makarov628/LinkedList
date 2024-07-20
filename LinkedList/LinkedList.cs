using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null) return false;

            Node prev = null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) break;
                prev = node;
                node = node.next;
            }

            if (prev == tail) return false;

            if (node == head && node == tail) Clear();
            else if (node == head) head = node.next;
            else if (node == tail) { prev.next = null; tail = prev; }
            else prev.next = node.next;

            return true;
        }

        public void RemoveAll(int _value)
        {
            if (head == null) return;

            Node prev = null;
            Node node = head;
            while (node != null)
            {
                if (node.value != _value)
                {
                    prev = node;
                    node = node.next;
                    continue;
                }

                if (node == head && node == tail)
                {
                    Clear();
                    return;
                }
                else if (node == head)
                {
                    head = node.next;
                    node = head;
                }
                else if (node == tail)
                {
                    prev.next = null;
                    tail = prev;
                }
                else
                {
                    prev.next = node.next;
                    node = node.next;
                }
            }

        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int counter = 0;
            Node node = head;
            while (node != null)
            {
                counter++;
                node = node.next;
            }
            return counter;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeToInsert == null) return;

            if (head == null && _nodeAfter == null)
            {
                AddInTail(_nodeToInsert);
                return;
            }

            Node node = head;
            if (_nodeAfter == null)
            {
                head = _nodeToInsert;
                head.next = node;
                return;
            }

            Node prev = null;
            while (node != null)
            {
                if (node == _nodeAfter) break;
                prev = node;
                node = node.next;
            }

            if (prev == tail) return;

            if (node == tail)
            {
                node.next = _nodeToInsert;
                node.next.next = null;
                tail = node.next;
                return;
            }

            Node link = node.next;
            node.next = _nodeToInsert;
            node.next.next = link;
        }

        public static List<int> Sum(LinkedList first, LinkedList second)
        {
            List<int> sums = new List<int>();
            if (first.Count() != second.Count())
                return sums;

            Node firstListNode = first.head;
            Node secondListNode = second.head;
            while (firstListNode != null)
            {
                sums.Add(firstListNode.value + secondListNode.value);
                firstListNode = firstListNode.next;
                secondListNode = secondListNode.next;
            }

            return sums;
        }

    }
}