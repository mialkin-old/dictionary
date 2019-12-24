using System.Collections.Generic;

namespace Dictionary.Services.Models
{
    public class ServiceResultModel<T>
    {
        public T Result { get; set; }
        public List<ServiceError> Errors { get; set; }
    }
}
