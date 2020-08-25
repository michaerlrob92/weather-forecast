using System;
using System.Text.Json.Serialization;

namespace WeatherForecast.Api.Infrastructure.Entity
{
    public class WeatherForecastDay
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [JsonIgnore]
        public int WeatherForecastLocationId { get; set; }
        
        [JsonPropertyName("id")]
        public long WeatherId { get; set; }
        
        [JsonPropertyName("applicable_date")]
        public DateTime ApplicableDate { get; set; }

        [JsonPropertyName("applicable_date_formatted")]
        public string ApplicableDateFormatted => ApplicableDate.ToString("yyyy-MM-dd");
        
        [JsonPropertyName("weather_state_name")]
        public string WeatherStateName { get; set; }
        
        [JsonPropertyName("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }
        
        [JsonPropertyName("wind_speed")]
        public decimal WindSpeed { get; set; }
        
        [JsonPropertyName("wind_direction")]
        public decimal WindDirection { get; set; }
        
        [JsonPropertyName("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }
        
        [JsonPropertyName("min_temp")]
        public decimal MinTemp { get; set; }
        
        [JsonPropertyName("max_temp")]
        public decimal MaxTemp { get; set; }
        
        [JsonPropertyName("the_temp")]
        public decimal TheTemp { get; set; }
        
        [JsonPropertyName("air_pressure")]
        public decimal AirPressure { get; set; }
        
        [JsonPropertyName("humidity")]
        public decimal Humidity { get; set; }
        
        [JsonPropertyName("visibility")]
        public decimal Visibility { get; set; }
        
        [JsonPropertyName("predictability")]
        public int Predictability { get; set; }
    }
}