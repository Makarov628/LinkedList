using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Stack<T>
   {

      private List<T> _stack;

      public Stack()
      {
         _stack = new List<T>();
      }

      public int Size()
      {
         return _stack.Count;
      }

      public T Pop()
      {
         if (Size() == 0)
            return default(T);

         T item = _stack[Size() - 1];
         _stack.RemoveAt(Size() - 1);
         return item;
      }

      public void Push(T val)
      {
         _stack.Add(val);
      }

      public T Peek()
      {
         if (Size() == 0)
            return default(T);

         return _stack[Size() - 1];
      }
   }

}

