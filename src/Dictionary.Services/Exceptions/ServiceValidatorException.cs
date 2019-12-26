using System;

namespace Dictionary.Services.Exceptions
{
    public class ServiceValidatorException : Exception
    {
        public ServiceValidatorException(string message) : base(message)
        {
        }
    }
}
