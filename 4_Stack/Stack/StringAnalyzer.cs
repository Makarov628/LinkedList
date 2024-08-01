using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class StringAnalyzer
   {
      public static bool AnalyzeBracketsUsingStack(string value)
      {
         var stack = new Stack<char>();
         foreach (char character in value)
         {
            if (character == '(') stack.Push(character);
            if (character == ')' && stack.Peek() == char.MinValue) return false;  
            if (character == ')') stack.Pop();
         }
         return stack.Size() == 0;
      }

      public static bool AnalyzeBracketsUsingMultiTypeStack(string value)
      {
         var stack = new MultiTypeStack();
         foreach (char character in value)
         {
            if (character == '(') stack.Push(character);
            if (character == ')' && !stack.IsHeadType<char>()) return false;  
            if (character == ')') stack.Pop<char>();
         }
         return stack.Size() == 0;
      }
   }

}

