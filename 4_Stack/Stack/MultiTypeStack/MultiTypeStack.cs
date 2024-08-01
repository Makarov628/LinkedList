using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
  public class MultiTypeStack
  {
    private class PeekedType : StackItemType
    {
      public PeekedType(Type itemType) : base(itemType) { }
    }

    private class EmptyType : StackItemType
    {
      public EmptyType() : base(typeof(object)) { }
      public override bool IsEquals(Type type) => false;
    }

    private List<object> _stack;

    public MultiTypeStack()
    {
      _stack = new List<object>();
    }

    private object Peek() =>
      _stack[Size() - 1];

    private object Pop()
    {
      object item = _stack[Size() - 1];
      _stack.RemoveAt(Size() - 1);
      return item;
    }

    public int Size() =>
      _stack.Count;

    public void Push<T>(T item) =>
      _stack.Add(item);

    private StackItemType PeekType()
    {
      if (Size() == 0)
        return new EmptyType();

      object peekedItem = Peek();
      return new PeekedType(peekedItem.GetType());
    }
    public bool IsHeadType<T>() =>
      PeekType().IsEquals(typeof(T));

    public bool TryToPop<T>(out T poppedValue)
    {
      bool isSuccess = IsHeadType<T>();

      if (isSuccess)
        poppedValue = (T)Pop();
      else
        poppedValue = default(T);

      return isSuccess;
    }

    public bool TryToPeek<T>(out T peekedValue)
    {
      bool isSuccess = IsHeadType<T>();

      if (isSuccess)
        peekedValue = (T)Peek();
      else
        peekedValue = default(T);

      return isSuccess;
    }

    public StackExtractResult<T> Peek<T>()
    {
      StackItemType peekedType = PeekType();

      if (peekedType is EmptyType)
        return StackExtractResult<T>.StackIsEmpty();

      if (!peekedType.IsEquals(typeof(T)))
        return StackExtractResult<T>.TypesDidNotMatch(peekedType.Type);

      return StackExtractResult<T>.Success((T)Peek());
    }

    public StackExtractResult<T> Pop<T>()
    {
      StackItemType peekedType = PeekType();

      if (peekedType is EmptyType)
        return StackExtractResult<T>.StackIsEmpty();

      if (!peekedType.IsEquals(typeof(T)))
        return StackExtractResult<T>.TypesDidNotMatch(peekedType.Type);

      return StackExtractResult<T>.Success((T)Pop());
    }


  }
}