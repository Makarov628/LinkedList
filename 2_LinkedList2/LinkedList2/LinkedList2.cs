using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
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

            Node node = head;
            Node prev = node.prev;
            while (node != null)
            {
                if (node.value == _value) break;
                prev = node;
                node = node.next;
            }

            if (prev == tail) return false;

            if (node.prev == null && node.next == null)
            {
                Clear();
            }
            if (node.prev == null && node.next != null)
            {
                head = node.next;
                head.prev = null;
            }
            if (node.prev != null && node.next == null)
            {
                tail = node.prev;
                tail.next = null;
            }
            if (node.prev != null && node.next != null)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }

            return true;
        }

        public void RemoveAll(int _value)
        {
            if (head == null) return;

            Node node = this.head;
            while (node != null)
            {
                if (node.value != _value)
                {
                    node = node.next;
                    continue;
                }
                if (node.prev == null && node.next == null)
                {
                    head = null;
                    tail = null;
                }
                if (node.prev == null && node.next != null)
                {
                    head = node.next;
                    head.prev = null;
                }
                if (node.prev != null && node.next == null)
                {
                    tail = node.prev;
                    tail.next = null;
                }
                if (node.prev != null && node.next != null)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                }
                node = node.next;
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
                node.prev = head;
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
                tail = _nodeToInsert;
                tail.prev = node;
                node.next = tail;
                return;
            }

            node.next.prev = _nodeToInsert;
            _nodeToInsert.next = node.next;
            node.next = _nodeToInsert;
            _nodeToInsert.prev = node;
        }

    }
}