using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using WeatherForecast.Api.Application.Queries;
using WeatherForecast.Api.Controllers;

namespace WeatherForecast.Api.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        private Mock<IMediator> _mockMediator;
        
        [SetUp]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>();
        }

        [Test]
        public async Task Get_Should_Pass_Query_To_Mediator()
        {
            _mockMediator.Setup(m => m.Send(It.IsAny<GetWeatherForecast>(), It.IsAny<CancellationToken>()));
            
            var controller = new WeatherForecastController(_mockMediator.Object);
            await controller.Get();

            _mockMediator.Verify(m => m.Send(It.IsAny<GetWeatherForecast>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}