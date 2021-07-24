using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DemoWebApi.Exceptions
{
    public class BadParamsExeception: BaseException
    {
        public BadParamsExeception()
        {
            this.httpCode = HttpStatusCode.BadRequest;
            this.message = "there no matching product.";
        }

        public BadParamsExeception(object messageObj)
        {
            this.httpCode = HttpStatusCode.BadRequest;
            this.message = messageObj;
        }

        public BadParamsExeception(string message)
            : base(message)
        {
            this.httpCode = HttpStatusCode.BadRequest;
            this.message = message;
        }
    }
}