using MediatR;
using WeatherForecast.Api.Infrastructure.Entity;

namespace WeatherForecast.Api.Application.Queries
{
    public class GetWeatherForecast : IRequest<WeatherForecastLocation>
    {
        public GetWeatherForecast(bool forceRefresh)
        {
            ForceRefresh = forceRefresh;
        }

        public bool ForceRefresh { get; }
    }
}