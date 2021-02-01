using System;

namespace OrbitaTech.TTLock
{
    public class TTLockAPIException : Exception
    {
        public int ErrorCode { get; } = -1;

        public TTLockAPIException() { }

        public TTLockAPIException(string message) : base(message) { }

        public TTLockAPIException(string message, Exception inner) : base(message, inner) { }

        public TTLockAPIException(int errorCode, string message)
            : this(message)
        {
            ErrorCode = errorCode;
        }
    }
}