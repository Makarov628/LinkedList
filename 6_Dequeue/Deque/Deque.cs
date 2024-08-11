using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class Deque<T>
  {
    public LinkedList<T> linkedList;
    private int count;

    public Deque()
    {
      count = 0;
      linkedList = new LinkedList<T>();
    }

    public void AddFront(T item)
    {
      linkedList.AddFirst(item);
      count += 1;
    }

    public void AddTail(T item)
    {
      linkedList.AddLast(item);
      count += 1;
    }

    public T RemoveFront()
    {
      if (Size() == 0)
        return default(T);

      LinkedListNode<T> item = linkedList.First;
      linkedList.RemoveFirst();
      count -= 1;
      
      return item.Value;
    }

    public T RemoveTail()
    {
      if (Size() == 0)
        return default(T);

      LinkedListNode<T> item = linkedList.Last;
      linkedList.RemoveLast();
      count -= 1;

      return item.Value;
    }

    public int Size()
    {
      return count; 
    }
  }

}

