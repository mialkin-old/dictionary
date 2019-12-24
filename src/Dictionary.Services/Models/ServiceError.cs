namespace Dictionary.Services.Models
{
    public class ServiceError
    {
        public string ErrorMessage { get; set; }

        public ServiceError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
