using Application.Services;
using Autofac;
using Domain.Repositories.Command;
using Domain.Repositories.Query;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using UnitTests.Mock.Infrastructure.Repositories.ExchangeTrade;
using UnitTests.Mock.Infrastructure.Services.CurrencyRates;
using WebApi.DependecyInjection.Modules;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestCollectionOrderer("UnitTests.TestCaseOrdering", "UnitTests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("UnitTests.ConfigureTestFramework", "UnitTests")]
namespace UnitTests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
            // mock env variables here if necessary               
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebApiModule>();            
            
            builder.RegisterGeneric(typeof(NullLogger<>)).As(typeof(ILogger<>)).SingleInstance().AsSelf();

            SetMockedDependencies(builder);
        }

        private static void SetMockedDependencies(ContainerBuilder builder)
        {
            builder.RegisterInstance(new CurrencyExchangeTradeCommandRepositoryMock().MockRepository().Object).As<ICurrencyExchangeTradeCommandRepository>();
            builder.RegisterInstance(new CurrencyExchangeTradeQueryRepositoryMock().MockRepository().Object).As<ICurrencyExchangeTradeQueryRepository>();
            builder.RegisterInstance(new CurrencyRatesServiceMock().MockService().Object).As<ICurrencyRatesService>();
        }
    }
}
