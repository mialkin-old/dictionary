using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Dictionary.WebUi.Misc
{
    public class ErrorResult
    {
        public IEnumerable<ValidationFailure> ValidationFailures { get; }

        public string ErrorMessage { get; }

        public ErrorResult(ValidationException ex)
        {
            ValidationFailures = ex.Errors;
        }
        public ErrorResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}