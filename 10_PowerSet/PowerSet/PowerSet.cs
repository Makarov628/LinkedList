using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

  public class PowerSet<T>
  {

    private readonly List<T> elements;

    public PowerSet()
    {
      elements = new List<T>();
    }

    public int Size()
    {
      return elements.Count;
    }

    public void Put(T value)
    {
      if (!Get(value))
        elements.Add(value);
    }

    public bool Get(T value)
    {
      return elements.Contains(value); ;
    }

    public bool Remove(T value)
    {
      return elements.Remove(value);
    }

    public PowerSet<T> Intersection(PowerSet<T> set2)
    {
      PowerSet<T> newSet = new PowerSet<T>();

      foreach (T element in elements)
        if (set2.Get(element))
          newSet.Put(element);

      return newSet;
    }

    public PowerSet<T> Union(PowerSet<T> set2)
    {
      PowerSet<T> newSet = new PowerSet<T>();

      foreach (T element in elements)
        newSet.Put(element);

      foreach (T element in set2.elements)
        newSet.Put(element);

      return newSet;
    }

    public PowerSet<T> Difference(PowerSet<T> set2)
    {
      PowerSet<T> newSet = new PowerSet<T>();

      foreach (T element in elements)
        newSet.Put(element);

      foreach (T item in set2.elements)
        newSet.Remove(item);

      return newSet;
    }

    public bool IsSubset(PowerSet<T> set2)
    {
      foreach (T element in set2.elements)
        if (!Get(element)) return false;

      return true;
    }
  }
}

