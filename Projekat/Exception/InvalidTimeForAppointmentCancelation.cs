using System;
using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    internal class InvalidTimeForAppointmentCancelation : Exception
    {
        public InvalidTimeForAppointmentCancelation()
        {
        }

        public InvalidTimeForAppointmentCancelation(string message) : base(message)
        {
        }

        public InvalidTimeForAppointmentCancelation(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTimeForAppointmentCancelation(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}