
using System.Runtime.Serialization;


namespace Bai13.Exceptions
{
    [Serializable]
    class PhoneException : Exception
    {
        private const string DefaultMessage = "Invalid Phone Number!";
        public PhoneException() : base(DefaultMessage) { }
        public PhoneException(string message) : base(DefaultMessage + " " + message) { }
        public PhoneException(string message, Exception innerException) : base(message, innerException) { }
        protected PhoneException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
