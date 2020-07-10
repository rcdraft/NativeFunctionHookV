using System;
using System.Runtime.Serialization;

namespace NativeFunctionHookV
{
    [Serializable]
    public class InvalidHandleableException : Exception
    {
        public InvalidHandleableException(object o) : base("The opreation is invalid because the specified " + o.GetType().Name + " is invalid.")
        {
        }

        public InvalidHandleableException(string message) : base(message)
        {
        }

        public InvalidHandleableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidHandleableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}