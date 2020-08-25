import React, { useState, useEffect } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { LogoutButton } from "../components/buttons/LogoutButton";
import { WeatherForecastLocationType } from "../types/WeatherForecast";
import { Loading } from "../components/Loading";
import { WeatherForecastDay } from "../components/WeatherForecastDay";

export const WeatherForecast: React.FC = () => {
  const apiUrl = process.env.REACT_APP_API_URL;

  const [weather, setWeather] = useState<WeatherForecastLocationType | null>(
    null
  );
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const { getAccessTokenSilently } = useAuth0();

  useEffect(() => {
    async function callSecureApi() {
      await loadWeatherForecast();
    }

    callSecureApi();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const loadWeatherForecast = async (forceRefresh: boolean = false) => {
    try {
      setLoading(true);

      const token = await getAccessTokenSilently();
      const response = await fetch(
        `${apiUrl}/weatherforecast?forceRefresh=${forceRefresh}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      const responseData = (await response.json()) as WeatherForecastLocationType;

      setLoading(false);
      setWeather(responseData);
    } catch (error) {
      setError(error.message);
      setWeather(null);
      setLoading(false);
    }
  };

  return (
    <div className="weather-forecast">
      <h1 className="text-center mb-5 display-5">
        Weather Forecast{" "}
        <small>
          <LogoutButton />
        </small>
      </h1>

      {loading && <Loading />}

      {error && (
        <div className="alert alert-danger">
          There was a problem retrieving the weather forecast:
          <br />
          <strong>{error}</strong>
        </div>
      )}

      {!loading && !weather && (
        <div className="text-center">
          <button
            className="btn btn-lg btn-primary mb-3"
            onClick={() => loadWeatherForecast(true)}
          >
            Load Weather Data
          </button>
        </div>
      )}

      {weather && (
        <div className="weather-forecast">
          <h4 className="text-center mb-0">{weather.title}</h4>

          {!loading && (
            <div className="text-center">
              <button
                className="btn btn-sm btn-link"
                onClick={() => loadWeatherForecast(true)}
              >
                Refresh
              </button>
            </div>
          )}
          <div className="mt-3 row row-cols-6">
            {weather.consolidated_weather.map((day) => (
              <WeatherForecastDay {...day} key={day.id} />
            ))}
          </div>
        </div>
      )}
    </div>
  );
};
