using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures
{
  public class NativeCash<T>
  {
    public int step;
    public int count;
    public int size;
    public string[] slots;
    public T[] values;
    public int[] hits;

    public NativeCash(int sz)
    {
      step = 1;
      count = 0;
      size = sz;
      slots = new string[size];
      values = new T[size];
      hits = new int[size];

      for (int i = 0; i < size; i++)
      {
        slots[i] = null;
        values[i] = default;
        hits[i] = 0;
      }
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

    private bool IsMatch(string[] allowedValues, string? value) =>
      allowedValues.Any((allowed) => allowed == value);

    private string[] Wrap(string value) =>
      new string[] { value };

    public int FindIndex(int startIndex, string value) =>
      FindIndexByValues(startIndex, Wrap(value));

    public int FindIndexByValues(int startIndex, string[] values)
    {
      if (IsMatch(values, slots[startIndex]))
        return startIndex;

      int offset = startIndex;
      bool loopEnds = false;
      while (!IsMatch(values, slots[offset]))
      {
        offset += step;

        if (offset >= slots.Length)
        {
          loopEnds = true;
          offset -= slots.Length;
        }

        if (loopEnds && offset >= startIndex)
          break;

        if (IsMatch(values, slots[offset]))
          return offset;
      }

      return -1;
    }

    public int SeekSlot(string key)
    {
      int startIndex = HashFun(key);
      int freeIndex = FindIndexByValues(startIndex, new string[] { null, key });

      if (freeIndex == -1)
        return MinHintsIndex();

      return freeIndex;
    }

    public bool IsKey(string key)
    {
      return FindIndex(HashFun(key), key) != -1;
    }

    public void Put(string key, T value)
    {
      int index = SeekSlot(key);

      slots[index] = key;
      values[index] = value;
      hits[index] = 0;
    }

    public int MinHintsIndex()
    {
      return Array.IndexOf(hits, hits.Min());
    }

    public T Get(string key)
    {
      int index = FindIndex(HashFun(key), key);
      if (index == -1) return default;

      hits[index] += 1;

      return values[index];
    }

    public bool Remove(string key)
    {
      int index = FindIndex(HashFun(key), key);
      if (index == -1) return false;

      slots[index] = null;
      values[index] = default;
      hits[index] = 0;

      return true;
    }

  }


}