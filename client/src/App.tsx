import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Loading } from "./components/Loading";
import { WeatherForecast } from "./pages/WeatherForecast";
import { LoginRequired } from "./pages/LoginRequired";

const App = () => {
  const { isLoading, isAuthenticated } = useAuth0();

  if (isLoading) {
    return (
      <div className="py-5">
        <Loading />
      </div>
    );
  }

  return (
    <div className="app py-5">
      <div className="container-lg">
        {isAuthenticated ? <WeatherForecast /> : <LoginRequired />}
      </div>
    </div>
  );
};

export default App;
