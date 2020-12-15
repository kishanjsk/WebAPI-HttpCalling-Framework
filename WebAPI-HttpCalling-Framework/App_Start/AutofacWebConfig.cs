using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using WebAPI_HttpCalling_Framework.Services.Autofac;
using WebAPI_HttpCalling_Framework.Services.ConfigService;
using WebAPI_HttpCalling_Framework.Services.ErrorHandler;

namespace WebAPI_HttpCalling_Framework.App_Start
{
    public class AutofacWebConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var errorDetailPolicyConfig = new ErrorDisplayConfig();
            config.IncludeErrorDetailPolicy = errorDetailPolicyConfig.ErrorPolicy();

            var builder = new ContainerBuilder();

            builder.RegisterHttpRequestMessage(config);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ConfigService>().As<IConfigService>().InstancePerRequest();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            AutofacGlobalConfig.Build(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}