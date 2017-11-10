using System;
using System.Runtime.Serialization;

namespace AirTrafficControl.ATC
{
    /// <summary>
    /// Represents AirTrafficControl Exceptions.
    /// </summary>
    public class AirTrafficControlException : Exception
    {
        public AirTrafficControlException()
        {
        }

        public AirTrafficControlException(string message) : base(message)
        {
        }

        public AirTrafficControlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AirTrafficControlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
