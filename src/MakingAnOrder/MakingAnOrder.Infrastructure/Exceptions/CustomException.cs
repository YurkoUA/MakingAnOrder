using System;
using System.Net;

namespace MakingAnOrder.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    }
}
