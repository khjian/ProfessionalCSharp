using System;
using System.Runtime.Serialization;

namespace Demo
{
    [Serializable]
    internal class UnexpectedException : Exception
    {
        public UnexpectedException()
        {
        }

        public UnexpectedException(string message) : base(message)
        {
        }

        public UnexpectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnexpectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}