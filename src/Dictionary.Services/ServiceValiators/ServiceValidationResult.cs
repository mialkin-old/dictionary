using System.Collections.Generic;

namespace Dictionary.Services.ServiceValiators
{
    public class ServiceValidationResult
    {
        public bool HasErrors { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
