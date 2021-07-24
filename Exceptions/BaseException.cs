using System;
using System.Net;

namespace DemoWebApi.Exceptions
{
    public class BaseException: Exception
    {
        public HttpStatusCode httpCode { get; set; }
        public string message { get; set; }

        public BaseException()
        {
            this.httpCode = HttpStatusCode.InternalServerError;
            this.message = "Internal Server Error";
        }
        public BaseException(string message)
            : base(message)
        {
            this.message = message;
        }
    }
}