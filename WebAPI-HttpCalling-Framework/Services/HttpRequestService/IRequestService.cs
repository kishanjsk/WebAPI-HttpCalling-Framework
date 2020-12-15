using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_HttpCalling_Framework.Services.HttpRequestService
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> GetHttpResponseAsync(string host, string uri, string token = "");
        Task<HttpResponseMessage> PostHttpResponseAsync<TResult>(string host, string uri, TResult data, string token = "");
        Task<HttpResponseMessage> PutHttpResponseAsync<TRequest>(string host, string uri, TRequest data, string token = "");

        // FOR SPECIFIC RESPONSE 
        #region SPECIFIC RESPONSE
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "");
        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "");
        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "");
        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "");
        #endregion SPECIFIC RESPONSE
    }
}
