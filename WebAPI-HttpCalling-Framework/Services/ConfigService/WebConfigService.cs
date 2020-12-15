using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAPI_HttpCalling_Framework.Services.ConfigService
{
    public interface IWebConfigService
    {
        string APIURL { get; }
        string GetURL { get; }
        string PostURL { get; }
    }

    public class WebConfigService : IWebConfigService
    {
        public string APIURL => ConfigurationManager.AppSettings["APIURL"];
        public string GetURL => ConfigurationManager.AppSettings["GetURL"];
        public string PostURL => ConfigurationManager.AppSettings["PostURL"];
    }
}