using Autofac;

namespace WebApi.DependecyInjection.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterUseCases(builder);
        }

        private void RegisterUseCases(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Application.ApplicationException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("UseCases"))
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();
        }
    }
}
