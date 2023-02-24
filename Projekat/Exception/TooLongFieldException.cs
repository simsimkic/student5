using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class TooLongFieldException : Exception
    {
        public TooLongFieldException()
        {
        }

        public TooLongFieldException(string message) : base(message)
        {
        }

        public TooLongFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooLongFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}