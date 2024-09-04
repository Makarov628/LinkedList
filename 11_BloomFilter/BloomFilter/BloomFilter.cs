using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
  public class BloomFilter
  {
    public int filter_len;
    public int bitArray;

    public BloomFilter(int f_len)
    {
      filter_len = f_len;
      bitArray = 0;
    }

    // хэш-функции
    public int Hash1(string str1)
    {
      int hash = 17;
      int result = 0;

      for (int i = 0; i < str1.Length; i++)
      {
        int code = (int)str1[i];
        result = (result * hash + code) % filter_len;
      }

      return result;
    }
    public int Hash2(string str1)
    {
      int hash = 223;
      int result = 0;

      for (int i = 0; i < str1.Length; i++)
      {
        int code = (int)str1[i];
        result = (result * hash + code) % filter_len;
      }

      return result;
    }

    public void Add(string str1)
    {
      int firstIndex = 1 << Hash1(str1);
      int secondIndex = 1 << Hash2(str1);
      bitArray |= firstIndex;
      bitArray |= secondIndex;
    }

    public bool IsValue(string str1)
    {
      int firstIndex = 1 << Hash1(str1);
      int secondIndex = 1 << Hash2(str1);

      int firstResult = bitArray & firstIndex;
      int secondResult = bitArray & secondIndex;

      return firstResult != 0 && secondResult != 0;
    }
  }
}

