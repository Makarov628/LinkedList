using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public static class Palindrome
  {
    public static bool IsPalindrome(string str)
    {
      Deque<char> deque = new Deque<char>();
      foreach (char character in str)
        deque.AddTail(character);

      while (deque.Size() > 1)
        if (deque.RemoveFront() != deque.RemoveTail()) return false;
      
      return true;
    }
  }

}

