using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class EmptyFieldException : Exception
    {
        public String FieldName {get; set;}
        public EmptyFieldException()
        {
        }

        public EmptyFieldException(string message) : base(message)
        {
            FieldName = message;
        }

        public EmptyFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}