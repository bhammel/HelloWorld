using HelloWorld.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Domain.Services
{
    public abstract class ServiceResponse
    {
        protected ServiceResponse()
        {
            ProblemDetails = new ValidationProblemDetails
            {
                Detail = ErrorTypes.InvalidRequestError
            };
        }

        public ValidationProblemDetails ProblemDetails { get; }
        public bool IsSuccessful => ProblemDetails.Errors.Count == 0;
    }

    public class ServiceResponse<T> : ServiceResponse
    {   
        public T Data { get; set; }
    }
}
