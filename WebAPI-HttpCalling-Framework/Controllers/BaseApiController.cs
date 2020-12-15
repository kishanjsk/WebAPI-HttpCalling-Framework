using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI_HttpCalling_Framework.Models;

namespace WebAPI_HttpCalling_Framework.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected static ApiResponse<T> GenerateResponse<T>(ApiResponse<T> apiResponse, HttpResponseMessage postResponse, string data)
        {
            apiResponse.statusCode = postResponse.StatusCode;
            if (postResponse.IsSuccessStatusCode)
            {
                //De-serializing the response received from api  
                T dataToPost = JsonConvert.DeserializeObject<T>(data);
                apiResponse.result = dataToPost;
                apiResponse.timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                apiResponse.message = "success";
                return apiResponse;
            }
            else
            {
                //De-serializing the response received from api  
                ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(data);
                apiResponse.message = errorResponse.message;
                apiResponse.timestamp = errorResponse.timestamp;
                return apiResponse;
            }
        }
        protected static ApiResponse<T> ErrorResponse<T>(ApiResponse<T> apiResponse, Exception ex)
        {
            apiResponse.statusCode = HttpStatusCode.InternalServerError;
            apiResponse.message = ex.Message;
            return apiResponse;
        }
    }
}