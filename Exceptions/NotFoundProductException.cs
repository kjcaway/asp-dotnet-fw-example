using System;
using System.Net;

namespace DemoWebApi.Exceptions
{
    public class NotFoundProductException: BaseException
    {
        public NotFoundProductException()
        {
            this.httpCode = HttpStatusCode.NotFound;
            this.message = "there no matching product.";
        }

        public NotFoundProductException(string message)
            : base(message)
        {
            this.httpCode = HttpStatusCode.NotFound;
            this.message = message;
        }
    }
}