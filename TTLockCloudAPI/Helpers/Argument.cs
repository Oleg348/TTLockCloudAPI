using System;

namespace OrbitaTech
{
    internal static class Argument
    {
        public static ArgumentNullException Null(string paramName)
        {
            return new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Check if obj is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <returns>Value under check.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null.</exception>
        public static T IsNotNull<T>(this T obj, string paramName)
            where T : class
        {
            if (obj is null)
                throw Null(paramName);

            return obj;
        }

        /// <summary>
        /// Check if obj is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <returns>Value under check.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null.</exception>
        public static T IsNotNull<T>(this T? obj, string paramName)
            where T : struct
        {
            if (obj is null)
                throw Null(paramName);

            return obj.Value;
        }

        public static ArgumentException Invalid(string paramName, string message)
        {
            return new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Check if object satisfy to provided delegate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="isValid"></param>
        /// <param name="paramName"></param>
        /// <param name="errorMessage"></param>
        /// <returns>Value under check.</returns>
        /// <exception cref="ArgumentException"><paramref name="obj"/> is not satisfy to <paramref name="isValid"/></exception>
        public static T IsValid<T>(this T obj, Predicate<T> isValid, string paramName, string errorMessage)
        {
            if (!isValid(obj))
                throw Invalid(paramName, errorMessage);

            return obj;
        }
    }
}
