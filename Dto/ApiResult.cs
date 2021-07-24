using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Dto
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiResult
    {
        public string version { get; set; }
        public string result { get; set; }
        public object data { get; set; }
        public object error { get; set; }
    }
}