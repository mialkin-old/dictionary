using Dictionary.Services.CustomExceptions;
using FluentValidation.Results;

namespace Dictionary.Services.ExtensionMethods
{
    public static class ValidationResultExtension
    {
        public static void ThrowIfNotValid(this ValidationResult result)
        {
            if (result.IsValid)
                return;
            
            throw new CustomValidationException(result.Errors);
        }
    }
}