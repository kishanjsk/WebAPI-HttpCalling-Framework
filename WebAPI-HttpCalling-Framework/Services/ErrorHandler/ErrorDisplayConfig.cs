using System.Configuration;
using System.Web.Configuration;
using System.Web.Http;

namespace WebAPI_HttpCalling_Framework.Services.ErrorHandler
{
    public class ErrorDisplayConfig
    {
        public IncludeErrorDetailPolicy ErrorPolicy()
        {
            try
            {
                var config = (CustomErrorsSection)
                    ConfigurationManager.GetSection("system.web/customErrors");

                switch (config?.Mode)
                {
                    case CustomErrorsMode.RemoteOnly:
                        return IncludeErrorDetailPolicy.LocalOnly;
                    case CustomErrorsMode.On:
                        return IncludeErrorDetailPolicy.Never;
                    case CustomErrorsMode.Off:
                        return IncludeErrorDetailPolicy.Always;
                    default:
                        return IncludeErrorDetailPolicy.Default;
                }
            }
            catch
            {
                return IncludeErrorDetailPolicy.Default;
            }
        }
    }
}