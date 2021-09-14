using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    //AssertConcern Vernon's Tip
    public class Validations
    {
        public static void ValidateIfEqual(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfDifferent(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int maximum, string message)
        {
            if(value.Trim().Length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int minimum, int maximum, string message)
        {
            int length = value.Trim().Length;
            if(length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateExpression(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfNull(object object1, string message)
        {
            if(object1 == null)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(double value, double minimum, double maximum, string message)
        {
            if(value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfMinorEqualMinimum(long value, long minimum, string message)
        {
            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfMinorEqualMinimum(double value, double minimum, string message)
        {
            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfMinorEqualMinimum(decimal value, decimal minimum, string message)
        {
            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfMinorEqualMinimum(int value, int minimum, string message)
        {
            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfMinorEqualMinimum(float value, float minimum, string message)
        {
            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfFalse(bool value, string message)
        {
            if (value)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfTrue(bool value, string message)
        {
            if (!value)
            {
                throw new DomainException(message);
            }
        }
    }
}
