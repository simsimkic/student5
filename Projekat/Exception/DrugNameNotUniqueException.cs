using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class DrugNameNotUniqueException : Exception
    {
        public DrugNameNotUniqueException()
        {
        }

        public DrugNameNotUniqueException(string message) : base(message)
        {
        }

        public DrugNameNotUniqueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DrugNameNotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}