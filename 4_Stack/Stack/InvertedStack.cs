using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class InvertedStack<T>
   {
      private List<T> _stack;

      public InvertedStack()
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

         T item = _stack[0];
         _stack.RemoveAt(0);
         return item;
      }

      public void Push(T val)
      {
         _stack.Insert(0, val);
      }

      public T Peek()
      {
         if (Size() == 0)
            return default(T);

         return _stack[0];
      }
   }

}

