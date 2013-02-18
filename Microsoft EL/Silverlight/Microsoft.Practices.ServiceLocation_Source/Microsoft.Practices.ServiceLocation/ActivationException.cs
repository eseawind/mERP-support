namespace Microsoft.Practices.ServiceLocation
{
    using System;

    public class ActivationException : Exception
    {
        public ActivationException()
        {
        }

        public ActivationException(string message) : base(message)
        {
        }

        public ActivationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

