using System;

namespace CloudMap.RegisterMe.Exceptions
{
    public class InvalidEnvironmentException : Exception
    {
        private const string DefaultExceptionMessage =
            "This method can only be used when your application runs in an EC2 instance.";

        public InvalidEnvironmentException() : base(DefaultExceptionMessage)
        {
        }

        public InvalidEnvironmentException(string message) : base(message)
        {
        }
    }
}