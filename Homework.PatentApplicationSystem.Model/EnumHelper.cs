using System;

namespace Homework.PatentApplicationSystem.Model
{
    public static class EnumHelper
    {
        public static T EnumParse<T>(this string value)
        {
            return value.EnumParse<T>(false);
        }

        public static T EnumParse<T>(this string value, bool ignoreCase)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            value = value.Trim();

            if (value.Length == 0)
                throw new ArgumentException("Must specify valid information for parsing in the string.", "value");

            Type t = typeof (T);

            if (!t.IsEnum)
                throw new ArgumentException("Type provided must be an Enum.", "T");

            var enumType = (T) Enum.Parse(t, value, ignoreCase);
            return enumType;
        }
    }
}