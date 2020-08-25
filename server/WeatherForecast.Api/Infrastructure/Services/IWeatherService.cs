using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Api.Infrastructure.Entity;

namespace WeatherForecast.Api.Infrastructure.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecastLocation> GetWeatherForecast(bool forceRefresh, CancellationToken cancellationToken = default);
    }
}