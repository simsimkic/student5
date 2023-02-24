using System;
using System.Runtime.Serialization;

namespace Controller
{
    [Serializable]
    internal class InvalidDrugConfirmationException : Exception
    {
        public InvalidDrugConfirmationException()
        {
        }

        public InvalidDrugConfirmationException(string message) : base(message)
        {
        }

        public InvalidDrugConfirmationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDrugConfirmationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}