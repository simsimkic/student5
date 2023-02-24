using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class MaxInventoryItemsReachedException : Exception
    {
        public MaxInventoryItemsReachedException()
        {
        }

        public MaxInventoryItemsReachedException(string message) : base(message)
        {
        }

        public MaxInventoryItemsReachedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaxInventoryItemsReachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}