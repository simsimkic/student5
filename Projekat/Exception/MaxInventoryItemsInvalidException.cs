using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class MaxInventoryItemsInvalidException : Exception
    {
        public MaxInventoryItemsInvalidException()
        {
        }

        public MaxInventoryItemsInvalidException(string message) : base(message)
        {
        }

        public MaxInventoryItemsInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaxInventoryItemsInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}