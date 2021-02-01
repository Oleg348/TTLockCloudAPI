using System;

namespace OrbitaTech
{
    internal static class Error
    {
        public static InvalidOperationException InvalidOperation(string message, Exception inner = null)
        {
            return inner is null
                ? new InvalidOperationException(message)
                : new InvalidOperationException(message, inner)
                ;
        }
    }
}
