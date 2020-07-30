using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Dictionary.Services.CustomExceptions
{
    public class CustomValidationException : Exception
    {
        public IList<ValidationFailure> ValidationFailures { get; }

        public CustomValidationException(IList<ValidationFailure> validationFailures)
        {
            ValidationFailures = validationFailures;
        }
    }
}