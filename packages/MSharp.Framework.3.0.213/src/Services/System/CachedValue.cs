﻿namespace System
{
    public static class CachedValue
    {
        /// <summary>
        /// Creates a CachedValue the specified value builder.
        /// </summary>
        public static CachedValue<T> Create<T>(Func<T> valueBuilder)
        {
            return new CachedValue<T>(valueBuilder);
        }
    }

    public class CachedValue<T>
    {
        /// <summary>
        /// Creates a new CachedValue instance.
        /// </summary>
        public CachedValue(T value)
        {
            _Value = value;
        }

        /// <summary>
        /// Initializes a new CachedValue instance with lazy loading support.
        /// </summary>
        /// <param name="valueBuilder">The value builder.</param>
        public CachedValue(Func<T> valueBuilder)
        {
            ValueBuilder = valueBuilder;
        }

        /// <summary>
        /// Stores the underlying value.
        /// </summary>
        T _Value;

        /// <summary>
        /// Gets the underlying value.
        /// </summary>
        public T Value
        {
            get
            {
                if (ValueBuilder != null)
                {
                    _Value = ValueBuilder();
                    ValueBuilder = null;
                }

                return _Value;
            }
        }
        Func<T> ValueBuilder;

        public static implicit operator T(CachedValue<T> value)
        {
            return value.Value;
        }

        public static implicit operator CachedValue<T>(T value)
        {
            return new CachedValue<T>(value);
        }
    }
}