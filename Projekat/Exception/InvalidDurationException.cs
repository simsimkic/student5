using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class InvalidDurationException : Exception
    {
        public InvalidDurationException()
        {
        }

        public InvalidDurationException(string message) : base(message)
        {
        }

        public InvalidDurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}