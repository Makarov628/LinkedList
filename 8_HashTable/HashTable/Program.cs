using System;

namespace AlgorithmsDataStructures
{

    public class Program
    {
        public static void Main(string[] args)
        {
            HashTable table = new HashTable(19, 3);

            int colCounter1 = 0;

            for (int i = 0; i < table.size * 2; i++)
            {
                string value = "" + (char)(i + 33);
                var putSlot = table.Put(value);
                Console.WriteLine($"Index = {i}, Value = {value}, HashFun = {table.HashFun(value)}, putSlot = {putSlot}");
                if (putSlot == -1) ++colCounter1;
            }
            System.Console.WriteLine("Число коллизий\n хэш-функции1:{0}\n", colCounter1);
            Console.ReadKey();
        }
    }
}