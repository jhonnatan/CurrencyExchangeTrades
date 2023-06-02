using Autofac;

namespace WebApi.DependecyInjection.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterControllers(builder);
        }

        private void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("Controllers"))
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();
        }
    }
}
