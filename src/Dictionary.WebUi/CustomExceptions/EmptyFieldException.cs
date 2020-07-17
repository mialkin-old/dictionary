using System.ComponentModel.DataAnnotations;

namespace Dictionary.WebUi.CustomExceptions
{
    public class EmptyFieldException : ValidationException
    {
        private readonly string _fieldName;

        public EmptyFieldException(string fieldName)
        {
            _fieldName = fieldName;
        }

        public override string ToString()
        {
            return $"Field {_fieldName} can't be empty.";
        }
    }
}