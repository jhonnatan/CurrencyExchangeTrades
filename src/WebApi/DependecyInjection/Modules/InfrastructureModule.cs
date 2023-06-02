using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Infrastructure;

namespace WebApi.DependecyInjection.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterMapper(builder);
            RegisterDataAccess(builder);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ConfigurationValueMissingException).Assembly)
               .Where(t => (t.Namespace ?? string.Empty).Contains("Services"))
               .AsImplementedInterfaces()
               .AsSelf()
               .InstancePerLifetimeScope();
        }

        private void RegisterDataAccess(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("DBCONN");

            builder.RegisterAssemblyTypes(typeof(ConfigurationValueMissingException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("DataAccess"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //if (!string.IsNullOrEmpty(connection))
            //{
            //    using Context context = new Context();
            //    context.Database.Migrate();
            //}
        }

        private void RegisterMapper(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ConfigurationValueMissingException).Assembly)
               .Where(t => (t.Namespace ?? string.Empty).Contains("Mapper")
                    && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
               .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);

                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
