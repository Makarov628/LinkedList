using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class HashTable
  {
    public int size;
    public int step;
    public string[] slots;

    public HashTable(int sz, int stp)
    {
      size = sz;
      step = stp;
      slots = new string[size];
      for (int i = 0; i < size; i++) slots[i] = null;
    }

    public int HashFun(string value)
    {
      if (string.IsNullOrEmpty(value))
        return 0;

      int sum = 0;
      foreach (char character in value)
        sum += character * 31;

      return sum % size;
    }

    public int SeekSlot(string value)
    {
      int hashIndex = HashFun(value);

      if (slots[hashIndex] == null)
        return hashIndex;
      else
      {
        int offset = hashIndex;
        bool loopEnds = false;

        while (slots[offset] != null)
        {
          offset += this.step;
          if (offset >= slots.Length)
          {
            loopEnds = true;
            offset -= slots.Length;
          }
          if (loopEnds && offset >= hashIndex)
            break;
          if (slots[offset] == null)
            return offset;
        }
      }

      return -1;
    }

    public int Put(string value)
    {
      int freeSlotIndex = SeekSlot(value);

      if (freeSlotIndex != -1)
        slots[freeSlotIndex] = value;

      return freeSlotIndex;
    }

    public int Find(string value)
    {
      int hashIndex = HashFun(value);

      if (slots[hashIndex] == value)
        return hashIndex;
      else
      {
        int offset = hashIndex;
        bool loopEnds = false;

        while (slots[offset] != value)
        {
          offset += this.step;
          if (offset >= slots.Length)
          {
            loopEnds = true;
            offset -= slots.Length;
          }
          if (loopEnds && offset >= hashIndex)
            break;
          if (slots[offset] == value)
            return offset;
        }
      }

      return -1;
    }
  }

}

