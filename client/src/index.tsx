import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { Auth0ProviderWithHistory } from "./providers/Auth0ProviderWithHistory";
import App from "./App";
import "./lib/FontAwesome";
import * as serviceWorker from "./serviceWorker";
import "./styles/main.scss";

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Auth0ProviderWithHistory>
        <App />
      </Auth0ProviderWithHistory>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);

serviceWorker.unregister();
