using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_HttpCalling_Framework.Services.ConfigService
{
    public interface IConfigService
    {
        IWebConfigService webConfigService { get; set; }
    }
}