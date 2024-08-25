using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class NativeDictionary<T>
  {
    public int size;
    public string[] slots;
    public T[] values;

    public NativeDictionary(int sz)
    {
      size = sz;
      slots = new string[size];
      values = new T[size];
    }

    public int HashFun(string key)
    {
      if (string.IsNullOrEmpty(key))
        return 0;

      int sum = 0;
      foreach (char character in key)
        sum += character;

      return sum % size;
    }

    public bool IsKey(string key)
    {
      return slots[HashFun(key)] == key;
    }

    public void Put(string key, T value)
    {
      int index = HashFun(key);
      slots[index] = key;
      values[index] = value;
    }

    public T Get(string key)
    {
      return IsKey(key) ? values[HashFun(key)] : default(T);
    }
  }


}