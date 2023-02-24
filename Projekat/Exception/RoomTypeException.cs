using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class RoomTypeException : Exception
    {
        public RoomTypeException()
        {
        }

        public RoomTypeException(string message) : base(message)
        {
        }

        public RoomTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}