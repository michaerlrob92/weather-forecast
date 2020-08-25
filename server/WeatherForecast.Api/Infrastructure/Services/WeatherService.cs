using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Api.Infrastructure.Entity;
using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherForecastDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        private const string BaseApiUrl = "https://www.metaweather.com/api/";

        public WeatherService(WeatherForecastDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherForecastLocation> GetWeatherForecast(bool forceRefresh, CancellationToken cancellationToken = default)
        {
            // If force refresh immediately call the api and update latest forecast data
            if (forceRefresh)
            {
                return await UpdateWeatherForecastDataFromApi(cancellationToken);
            }
            
            var location = await _context.WeatherForecastLocations
                .Include(l => l.WeatherForecastDays)
                .FirstOrDefaultAsync(l => l.Title == "Belfast", cancellationToken);
            
            // Refresh data if doesn't exist or older than 1 day
            if (location == null || location.Time <= DateTime.Now.AddDays(-1))
            {
                return await UpdateWeatherForecastDataFromApi(cancellationToken);
            }
            
            return location;
        }

        private async Task<WeatherForecastLocation> UpdateWeatherForecastDataFromApi(CancellationToken cancellationToken = default)
        {
            // First search for the location woeid (I don't expect this to change, but just in case)
            var belfastWoEId = await GetBelfastWoEId();

            var locationForecastApiUrl = BaseApiUrl
                .AppendPathSegments("location", belfastWoEId);
            
            // Get the forecast data for the location
            using var httpClient = _httpClientFactory.CreateClient();
            var responseJson = await httpClient.GetStringAsync(locationForecastApiUrl);
            var response = JsonSerializer.Deserialize<WeatherForecastLocation>(responseJson);

            var location = await _context.WeatherForecastLocations
                .Include(l => l.WeatherForecastDays)
                .FirstOrDefaultAsync(l => l.WoEId == response.WoEId, cancellationToken);

            // Add or update the location with the forecast days
            if (location == null)
            {
                location = response;
                _context.Add(location);
            }
            else
            {
                location.WeatherForecastDays = response.WeatherForecastDays;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return location;
        }

        private async Task<int> GetBelfastWoEId()
        {
            var belfastLocationSearchApiUrl = BaseApiUrl
                .AppendPathSegments("location", "search")
                .SetQueryParam("query", "belfast");

            using var httpClient = _httpClientFactory.CreateClient();
            var responseJson = await httpClient.GetStringAsync(belfastLocationSearchApiUrl);
            var response = JsonSerializer.Deserialize<MetaWeatherLocationSearchResponse[]>(responseJson);
            return response?.FirstOrDefault()?.WoEId ?? -1;
        }
    }
}