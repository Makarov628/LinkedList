using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class DynArray<T>
  {
    public T[] array;
    public int count;
    public int capacity;

    public DynArray()
    {
      count = 0;
      MakeArray(16);
    }

    public void MakeArray(int new_capacity)
    {
      if (new_capacity < 16)
        new_capacity = 16;

      if (array != null)
      {
        var newArray = new T[new_capacity];
        Array.ConstrainedCopy(array, 0, newArray, 0, count);
        array = newArray;
      }
      else
      {
        array = new T[new_capacity];
      }

      capacity = new_capacity;
    }

    public T GetItem(int index)
    {
      if (index < 0 || index >= count)
        throw new IndexOutOfRangeException();

      return array[index];
    }

    public void Append(T itm)
    {
      if (capacity < count + 1)
        MakeArray(capacity * 2);

      array[count] = itm;
      count += 1;
    }

    public void Insert(T itm, int index)
    {
      if (index < 0 || index > count)
        throw new IndexOutOfRangeException();

      if (index == count)
      {
        Append(itm);
        return;
      }

      if (capacity < count + 1)
        MakeArray(capacity * 2);

      for (int i = count - 1; i >= index; i--)
      {
        array[i + 1] = array[i];
      }

      array[index] = itm;
      count += 1;
    }

    public void Remove(int index)
    {
      if (index < 0 || index >= count)
        throw new IndexOutOfRangeException();

      array[index] = default(T);
      for (int i = index + 1; i < count; i++)
      {
        array[i - 1] = array[i];
      }

      count -= 1;
      if ((double)count / capacity < 0.5)
        MakeArray((int)(capacity / 1.5));
    }

  }
}