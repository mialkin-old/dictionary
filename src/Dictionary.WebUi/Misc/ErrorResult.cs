using System.Collections.Generic;
using Dictionary.Services.CustomExceptions;
using FluentValidation.Results;

namespace Dictionary.WebUi.Misc
{
    public class ErrorResult
    {
        public IList<ValidationFailure> ValidationFailures { get; }

        public ErrorResult(CustomValidationException ex)
        {
            ValidationFailures = ex.ValidationFailures;
        }
    }
}