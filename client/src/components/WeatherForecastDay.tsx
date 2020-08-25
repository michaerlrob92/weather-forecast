import React from "react";
import moment from "moment";
import { WeatherForecastDayType } from "../types/WeatherForecast";

export const WeatherForecastDay: React.FC<WeatherForecastDayType> = ({
  weather_state_name,
  weather_state_abbr,
  applicable_date,
  the_temp,
}) => {
  const imageUrl = `https://www.metaweather.com/static/img/weather/${weather_state_abbr}.svg`;
  const dateFormatted = moment(applicable_date).format("Do MMM");
  return (
    <div className="weather-forecast-day">
      <p className="text-center font-weight-bold mb-3">{dateFormatted}</p>
      <div className="text-center">
        <img
          src={imageUrl}
          width="64"
          height="64"
          alt={weather_state_name}
          className="img-fluid mb-2"
        />
        <p className="mb-2">{weather_state_name}</p>
        <p className="mb-0 font-weight-bold">{Math.round(the_temp)}°</p>
      </div>
    </div>
  );
};
