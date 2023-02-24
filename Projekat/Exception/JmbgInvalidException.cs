using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class JmbgInvalidException : Exception
    {
        public JmbgInvalidException()
        {
        }

        public JmbgInvalidException(string message) : base(message)
        {
        }

        public JmbgInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JmbgInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}