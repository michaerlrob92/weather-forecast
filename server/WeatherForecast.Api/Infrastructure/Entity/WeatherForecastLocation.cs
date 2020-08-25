using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace WeatherForecast.Api.Infrastructure.Entity
{
    public class WeatherForecastLocation
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [JsonPropertyName("woeid")]
        public int WoEId { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }
        
        [JsonPropertyName("latt_long")]
        public string LatLong { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude => LatLong?.Split(",").FirstOrDefault();
        
        [JsonPropertyName("longitude")]
        public string Longitude => LatLong?.Split(",").LastOrDefault();
        
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        
        [JsonPropertyName("sun_rise")]
        public DateTime? Sunrise { get; set; }
        
        [JsonPropertyName("sun_set")]
        public DateTime? Sunset { get; set; }
        
        [JsonPropertyName("timezone_name")]
        public string TimezoneName { get; set; }
        
        [JsonPropertyName("consolidated_weather")]
        public List<WeatherForecastDay> WeatherForecastDays { get; set; }
    }
}