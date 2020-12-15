using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPI_HttpCalling_Framework.Models
{
    public class ApiResponse<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public string responsecode { get; set; }
        public string message { get; set; }
        public T result { get; set; }
        public string timestamp { get; set; }
    }
}