using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class Node<T>
  {
    public T value;
    public Node<T> next, prev;

    public Node(T _value)
    {
      value = _value;
      next = null;
      prev = null;
    }
  }

  public class OrderedList<T>
  {
    public Node<T> head, tail;
    private bool _ascending;
    private int _count;

    public OrderedList(bool asc)
    {
      head = null;
      tail = null;
      _ascending = asc;
      _count = 0;
    }

    public int Compare(T v1, T v2)
    {
      if (typeof(T) == typeof(string))
        return (v1.ToString().Trim()).CompareTo(v2.ToString().Trim());

      if (typeof(T) == typeof(int))
      {
        int int1 = Convert.ToInt32(v1);
        int int2 = Convert.ToInt32(v2);
        if (int1 > int2) return 1;
        if (int1 < int2) return -1;
      }

      return 0;
    }

    public void Add(T value)
    {
      var newItem = new Node<T>(value);

      if (Count() == 0)
      {
        head = newItem;
        tail = newItem;
        _count += 1;
        return;
      }
      
       _count += 1;
      int direction = _ascending ? 1 : -1;
      
      int headCompared = Compare(head.value, newItem.value) * direction;
      if (headCompared == 1 || headCompared == 0)
      {
        AddInHead(newItem);
        return;
      }

      int tailCompared = Compare(tail.value, newItem.value) * direction;
      if (tailCompared == 0 || tailCompared == -1)
      {
        AddInTail(newItem);
        return;
      }

      Node<T> node;
      for (node = head.next; node != tail; node = node.next)
        if (Compare(node.value, newItem.value) == direction) break;

      node.prev.next = newItem;
      newItem.prev = node.prev;
      newItem.next = node;
      node.prev = newItem;
    }

    private void AddInHead(Node<T> node)
    {
      node.next = head;
      head.prev = node;
      head = node;
      head.prev = null;
    }

    private void AddInTail(Node<T> node)
    {
      tail.next = node;
      node.prev = tail;
      tail = node;
      tail.next = null;
    }

    public Node<T> Find(T val)
    {
      if (Count() == 0)
        return null;

      int direction = _ascending ? 1 : -1;
      Node<T> node;
      for (node = head; node != tail; node = node.next)
      {
        if (Compare(node.value, val) == direction) return null;
        if (Compare(node.value, val) == 0) return node;
      }

      return null;
    }

    public void Delete(T val)
    {
      if (head == null) return;

      var node = head;
      var prev = node.prev;
      while (node != null)
      {
        if (node.value.Equals(val)) break;
        prev = node;
        node = node.next;
      }

      if (prev == tail) return;

      if (node.prev == null && node.next == null)
      {
        Clear(_ascending);
        return;
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

      _count -= 1;
    }

    public void Clear(bool asc)
    {
      _ascending = asc;
      head = null;
      tail = null;
      _count = 0;
    }

    public int Count()
    {
      return _count;
    }

    public List<Node<T>> GetAll()
    {
      List<Node<T>> r = new List<Node<T>>();
      Node<T> node = head;
      while (node != null)
      {
        r.Add(node);
        node = node.next;
      }
      return r;
    }
  }

}