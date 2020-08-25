using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Contrib.HttpClient;
using NUnit.Framework;
using WeatherForecast.Api.Infrastructure;
using WeatherForecast.Api.Infrastructure.Entity;
using WeatherForecast.Api.Infrastructure.Services;

namespace WeatherForecast.Api.Tests.Infrastructure.Services
{
    public class WeatherServiceTests
    {
        private const string BaseApiUrl = "https://www.metaweather.com/api";
        private WeatherForecastDbContext _context;
        private WeatherForecastDbContext _emptyContext;
        private IHttpClientFactory _httpClientFactory;
        private const int BelfastWoEId = 1;
        private const int FakeBelfastWoEId = 2;

        [SetUp]
        public void Setup()
        {
            _context = GenerateDbContext(false);
            _emptyContext = GenerateDbContext(true);
            
            var handler = new Mock<HttpMessageHandler>();
            handler.SetupRequest(HttpMethod.Get, $"{BaseApiUrl}/location/search?query=belfast")
                .ReturnsResponse("[{\"woeid\":" + FakeBelfastWoEId + ",\"title\":\"Belfast\"}]");
            handler.SetupRequest(HttpMethod.Get, $"{BaseApiUrl}/location/{FakeBelfastWoEId}")
                .ReturnsResponse("{\"woeid\":" + FakeBelfastWoEId + "}");
            
            _httpClientFactory = handler.CreateClientFactory();
        }

        [Test]
        public async Task GetWeatherForecast_Should_Return_ExistingData()
        {
            var service = new WeatherService(_context, _httpClientFactory);
            var result = await service.GetWeatherForecast(false);
            
            Assert.AreEqual(result.WoEId, BelfastWoEId);
            Assert.AreEqual(result.Title, "Belfast");
        }
        
        [Test]
        public async Task GetWeatherForecast_Should_Fetch_NewData_If_ForceRefresh()
        {
            const int fakeWoEId = 2;
            
            var service = new WeatherService(_context, _httpClientFactory);
            var result = await service.GetWeatherForecast(true);
            
            Assert.AreEqual(result.WoEId, fakeWoEId);
        }
        
        [Test]
        public async Task GetWeatherForecast_Should_Fetch_NewData_If_DoesntExist()
        {
            const int fakeWoEId = 2;
            
            var service = new WeatherService(_emptyContext, _httpClientFactory);
            var result = await service.GetWeatherForecast(false);
            
            Assert.AreEqual(result.WoEId, fakeWoEId);
        }
        
        private static WeatherForecastDbContext GenerateDbContext(bool empty)
        {
            var options = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new WeatherForecastDbContext(options);
            
            if (!empty)
            {
                context.WeatherForecastLocations.Add(new WeatherForecastLocation
                {
                    WoEId = BelfastWoEId,
                    Title = "Belfast",
                    Time = DateTime.Now
                });
                context.SaveChanges();
            }

            return context;
        }
    }
}