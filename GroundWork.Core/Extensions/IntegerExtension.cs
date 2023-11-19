using System;
namespace GroundWork.Core.Extensions
{
    public static class IntegerExtension
    {
        public static T ToEnum<T>(this int value) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}

