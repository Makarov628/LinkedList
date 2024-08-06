using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public interface IQueue<T>
  {
    void Enqueue(T item);
    T Dequeue();
    int Size();
  }

  public class Queue<T>: IQueue<T>
  {
    private List<T> list;

    public Queue()
    {
      list = new List<T>();
    }

    public void Enqueue(T item)
    {
      list.Add(item);
    }

    public T Dequeue()
    {
      if (Size() == 0)
        return default(T);

      T item = list[0];
      list.RemoveAt(0);
      return item;
    }

    public int Size()
    {
      return list.Count;
    }

  }
}

