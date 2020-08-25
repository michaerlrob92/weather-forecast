using System.Text.Json.Serialization;

namespace WeatherForecast.Api.Model
{
    public class MetaWeatherLocationSearchResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }
        
        [JsonPropertyName("latt_long")]
        public string LatLong { get; set; }
        
        [JsonPropertyName("woeid")]
        public int WoEId { get; set; }
        
        [JsonPropertyName("distance")]
        public int? Distance { get; set; }
    }
}