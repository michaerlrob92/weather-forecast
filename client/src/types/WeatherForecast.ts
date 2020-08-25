export type WeatherForecastLocationType = {
  title: string;
  location_type: string;
  latitude: number;
  longitude: number;
  time: Date;
  sunrise?: Date;
  sunset?: Date;
  timezone_name: string;
  consolidated_weather: WeatherForecastDayType[];
};

export type WeatherForecastDayType = {
  id: number;
  applicable_date: string;
  applicable_date_formatted: Date;
  weather_state_name: string;
  weather_state_abbr: string;
  wind_speed: number;
  wind_direction: number;
  wind_direction_compass: string;
  min_temp: number;
  max_temp: number;
  the_temp: number;
  air_pressure: number;
  humidity: number;
  visibility: number;
  predictability: number;
};
