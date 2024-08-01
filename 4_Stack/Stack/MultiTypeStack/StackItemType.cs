using System;

namespace AlgorithmsDataStructures
{
    public abstract class StackItemType
    {
        public Type Type { get; private set; }
        protected StackItemType(Type itemType)
        {
            Type = itemType;
        }

        public virtual bool IsEquals(Type type) => Type == type;
    }
}