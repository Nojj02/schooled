using System;

namespace Schooled.Model
{
    public struct Year
    {
        private readonly int? _value;

        public Year(int value)
        {
            if (value < 1 || value > 9999)
            {
                throw new InvalidYearException(value);
            }

            _value = value;
        }

        public int Value => _value ?? 1;

        public static bool operator >=(Year obj, Year other)
        {
            return obj._value >= other._value;
        }

        public static bool operator <=(Year obj, Year other)
        {
            return obj._value <= other._value;
        }

        public static implicit operator Year(int value)
        {
            return new Year(value);
        }

        public override bool Equals(object obj)
        {
            return Equals((Year)obj);
        }

        public bool Equals(Year other)
        {
            return _value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public class InvalidYearException : Exception
        {
            public InvalidYearException(object obj)
                : base($"{obj} is not a valid year")
            {
                
            }
        }
    }
}