using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WeatherForecast.Api.Infrastructure.Entity;
using WeatherForecast.Api.Infrastructure.Services;

namespace WeatherForecast.Api.Application.Queries
{
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecast, WeatherForecastLocation>
    {
        private readonly IWeatherService _weatherService;

        public GetWeatherForecastHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<WeatherForecastLocation> Handle(GetWeatherForecast request, CancellationToken cancellationToken)
        {
            return await _weatherService.GetWeatherForecast(request.ForceRefresh, cancellationToken);
        }
    }
}