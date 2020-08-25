using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using WeatherForecast.Api.Application.Queries;
using WeatherForecast.Api.Infrastructure.Entity;
using WeatherForecast.Api.Infrastructure.Services;

namespace WeatherForecast.Api.Tests.Application
{
    public class GetWeatherForecastHandlerTests
    {
        private Mock<IWeatherService> _mockWeatherService;
        
        [SetUp]
        public void Setup()
        {
            _mockWeatherService = new Mock<IWeatherService>();
        }

        [Test]
        public async Task Handle_Should_Return_Weather_Forecast_Location()
        {
            const int weatherForecastLocationId = 1;
            
            _mockWeatherService
                .Setup(m => m.GetWeatherForecast(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new WeatherForecastLocation {Id = weatherForecastLocationId});

            var handler = new GetWeatherForecastHandler(_mockWeatherService.Object);
            var result = await handler.Handle(new GetWeatherForecast(false), CancellationToken.None);
            
            Assert.AreEqual(result.Id, weatherForecastLocationId);
        }
    }
}