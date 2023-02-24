using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class NoNameException : Exception
    {
        public NoNameException()
        {
        }

        public NoNameException(string message) : base(message)
        {
        }

        public NoNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}