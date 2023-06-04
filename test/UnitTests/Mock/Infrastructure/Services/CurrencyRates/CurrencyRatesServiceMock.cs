using Application.Services;
using Domain.Dtos;
using Moq;
using Newtonsoft.Json;

namespace UnitTests.Mock.Infrastructure.Services.CurrencyRates
{
    public class CurrencyRatesServiceMock
    {
        public Mock<ICurrencyRatesService> MockService()
        {
            var currencyRatesServiceMock = new Mock<ICurrencyRatesService>();

            var sampleJsonSuccessResponse = File.ReadAllText(Path.Combine
                (Util.GetRootTestPath(), "SampleResponse", "FixerLatestRatesSuccessJsonResponse.json"));
            var successResponse = Task.FromResult(JsonConvert.DeserializeObject<LatestRatesResponse>(sampleJsonSuccessResponse));
            
            currencyRatesServiceMock.Setup(i => i.GetLatestRates(It.IsAny<string>(), It.IsAny<List<string>>()))
                .Returns(successResponse);

            var sampleJsonErrorResponse = File.ReadAllText(Path.Combine
                (Util.GetRootTestPath(), "SampleResponse", "FixerLatestRatesErrorJsonResponse.json"));
            var errorResponse = Task.FromResult(JsonConvert.DeserializeObject<LatestRatesResponse>(sampleJsonErrorResponse));

            currencyRatesServiceMock.Setup(i => i.GetLatestRates("notfound", new List<string>() { "notfound" }))
                .Returns(errorResponse);


            return currencyRatesServiceMock;
        }
    }
}
