using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_HttpCalling_Framework.Models;
using WebAPI_HttpCalling_Framework.Services.ConfigService;
using WebAPI_HttpCalling_Framework.Services.HttpRequestService;

namespace WebAPI_HttpCalling_Framework.Controllers
{
    public class ValuesController : BaseApiController
    {

        private readonly IRequestService _requestService;
        private readonly IConfigService _config;
        public ValuesController(IConfigService config, IRequestService requestService)
        {
            _config = config;
            _requestService = requestService;
        }    // GET api/values
      
        [HttpGet]
        [Route("api/Values/{proposalId}")]
        public async Task<ApiResponse<GetProposalResponse>> GetAsync(string proposalId)
        {
            ApiResponse<GetProposalResponse> apiResponse = new ApiResponse<GetProposalResponse>();
            try
            {
                var postResponse = await _requestService.GetHttpResponseAsync(
                    host: _config.webConfigService.APIURL,
                    uri: _config.webConfigService.GetURL,
                    token: Request.Headers.GetValues("Authorization").First());

                return GenerateResponse(apiResponse, postResponse, await postResponse.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return ErrorResponse(apiResponse, ex);
            }
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
