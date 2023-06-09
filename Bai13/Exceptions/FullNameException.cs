
using System.Runtime.Serialization;


namespace Bai13.Exceptions
{
    [Serializable]
    class FullNameException : Exception
    {
        private const string DefaultMessage = "Invalid Full Name!";
        public FullNameException() : base(DefaultMessage) { }
        public FullNameException(string message) : base(DefaultMessage + " " + message) { }
        public FullNameException(string message, Exception innerException) : base(message, innerException) { }
        protected FullNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
