using Autofac;
using WebApi.DependecyInjection.Modules;

namespace WebApi.DependecyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebApiModule>();

            return builder;
        }
    }
}
