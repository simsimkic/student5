using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class JmbgNotUniqueException : Exception
    {
        public JmbgNotUniqueException()
        {
        }

        public JmbgNotUniqueException(string message) : base(message)
        {
        }

        public JmbgNotUniqueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JmbgNotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}