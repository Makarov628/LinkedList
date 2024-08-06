using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class QueueWithLinkedList<T>: IQueue<T>
  {
    private LinkedList<T> linkedList;
    private int count;

    public QueueWithLinkedList()
    {
      count = 0;
      linkedList = new LinkedList<T>();
    }

    public void Enqueue(T item)
    {
      linkedList.AddLast(item);
      count += 1;
    }

    public T Dequeue()
    {
      if (Size() == 0)
        return default(T);

      LinkedListNode<T> item = linkedList.First;
      linkedList.RemoveFirst();
      count -= 1;
      
      return item.Value;
    }

    public int Size()
    {
      return count;
    }

  }
}

