
using System.Runtime.Serialization;


namespace Bai13.Exceptions
{
    [Serializable]
    class EmailException : Exception
    {
        private const string DefaultMessage = "Invalid Email!";
        public EmailException() : base(DefaultMessage) { }
        public EmailException(string message) : base(DefaultMessage + " " + message) { }
        public EmailException(string message, Exception innerException) : base(message, innerException) { }
        protected EmailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
