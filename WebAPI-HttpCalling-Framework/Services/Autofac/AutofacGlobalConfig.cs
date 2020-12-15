using Autofac;
using WebAPI_HttpCalling_Framework.Services.HttpRequestService;

namespace WebAPI_HttpCalling_Framework.Services.Autofac
{
    public static class AutofacGlobalConfig
    {
        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterType<RequestService>().As<IRequestService>();

            //AutofacCustodianConfig.Build(builder);
            //AutofacOrganizationConfig.Build(builder);
            //AutofacLoggingConfig.Build(builder);
        }
    }
}