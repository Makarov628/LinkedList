using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class PostfixExpression
   {
      public static int Postfix(MultiTypeStack stack)
      {
         Stack<int> numbers = new Stack<int>();

         while (stack.Size() > 0)
            if (stack.TryToPop(out int number)) numbers.Push(number);
            else if (stack.TryToPop(out char operation)) numbers.Push(MathOperation(numbers.Pop(), operation, numbers.Pop()));
            else break;

         return numbers.Pop();
      }

      public static int MathOperation(int secondNumber, char character, int firstNumber) =>
         character switch
         {
            '+' => firstNumber + secondNumber,
            '-' => firstNumber - secondNumber,
            '*' => firstNumber * secondNumber,
            '/' => firstNumber / secondNumber,
            _ => 0,
         };
   }

}

