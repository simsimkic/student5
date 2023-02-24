using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class RoomSizeException : Exception
    {
        public RoomSizeException()
        {
        }

        public RoomSizeException(string message) : base(message)
        {
        }

        public RoomSizeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}