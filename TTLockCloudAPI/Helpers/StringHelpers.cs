using System;

using Newtonsoft.Json;

namespace OrbitaTech
{
    internal static class StringHelpers
    {
        public static string SerializeToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ParseJson<T>(this string jsonString)
            where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// Check if string is not null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is null or empty</exception>
        public static string IsNotNullOrEmpty(this string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw Argument.Invalid(paramName, $"{paramName} can't be null or empty");

            return value;
        }
    }
}
