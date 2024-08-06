using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class QueueWithTwoStacks<T>: IQueue<T>
  {
    private Stack<T> enqueueStack;
    private Stack<T> dequeueStack;

    public QueueWithTwoStacks()
    {
      enqueueStack = new Stack<T>();
      dequeueStack = new Stack<T>();
    }

    public void Enqueue(T item)
    {
      enqueueStack.Push(item);
    }

    public T Dequeue()
    {
      if (dequeueStack.Count == 0)
        while (enqueueStack.Count > 0)
          dequeueStack.Push(enqueueStack.Pop());

      if (dequeueStack.Count == 0)
        return default(T);

      return dequeueStack.Pop();
    }

    public int Size()
    {
      return enqueueStack.Count + dequeueStack.Count;
    }

  }
}

