using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class DrugQuantityException : Exception
    {
        public DrugQuantityException()
        {
        }

        public DrugQuantityException(string message) : base(message)
        {
        }

        public DrugQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DrugQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}