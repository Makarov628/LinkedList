

using System;

namespace AlgorithmsDataStructures
{
    public enum StackExtractStatus
    {
        Success,
        TypesDidNotMatch,
        StackIsEmpty
    }

    public class StackExtractResult<T>
    {
        private T _value;
        private Type _expectedType = null;

        public StackExtractStatus Status;
        public bool IsSuccess;

        protected StackExtractResult(T value, StackExtractStatus status)
        {
            _value = value;
            _expectedType = typeof(T);
            Status = status;
            IsSuccess = status == StackExtractStatus.Success;
        }

        protected StackExtractResult(Type expectedType, StackExtractStatus status)
        {
            _value = default;
            _expectedType = expectedType;
            Status = status;
            IsSuccess = false;
        }

        protected StackExtractResult(StackExtractStatus status)
        {
            _value = default;
            _expectedType = null;
            Status = status;
            IsSuccess = false;
        }

        public static StackExtractResult<T> Success(T value) => new StackExtractResult<T>(value, StackExtractStatus.Success);
        public static StackExtractResult<T> TypesDidNotMatch(Type expectedType) => new StackExtractResult<T>(expectedType, StackExtractStatus.TypesDidNotMatch);
        public static StackExtractResult<T> StackIsEmpty() => new StackExtractResult<T>(StackExtractStatus.StackIsEmpty);

        public T GetValue()
        {
            if (_expectedType == null)
                throw new NullReferenceException($"Value is null. Stack is empty.");

            if (typeof(T) != _expectedType)
                throw new TypeAccessException($"You can not get value with type \"{typeof(T).Name}\", try to get type \"{_expectedType.Name}\"");

            return _value;
        }
    }
}