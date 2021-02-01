using System;

namespace OrbitaTech
{
    internal static class EnumHelpers
    {
        public static bool Exist<T>(this T value)
            where T : struct, Enum
        {
            return Enum.IsDefined(typeof(T), value);
        }

        /// <summary>
        /// Check if Enum value exists in its type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value"></param>
        /// <returns>Input value.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> doesn't exist in its type.</exception>
        public static T IsExist<T>(this T value)
            where T : struct, Enum
        {
            if (!Exist(value))
                throw Argument.Invalid(nameof(value), $"Value ({value}) doesn't exist in Enum ({typeof(T).Name})");

            return value;
        }
    }
}
