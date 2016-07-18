using System;
using System.Runtime.Serialization;

namespace Demo
{
    [Serializable]
    internal class SalesSpyFoundException : Exception
    {
        public SalesSpyFoundException()
        {
        }

        public SalesSpyFoundException(string message) : base(message)
        {
        }

        public SalesSpyFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SalesSpyFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}