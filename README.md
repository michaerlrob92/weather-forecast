# Weather Forecast

## Project
Create an .NET Core MVC application with React front-end that will display the weather forecast for the next 5 days in Belfast.

## Specific Requirements
- Weather forecast must only be visible to **authenticated** users
- The application will communicate with the REST Api: https://www.metaweather.com/api/
- The application will display the next 5 days of weather for Belfast
- The application will display the date, weather state and an image to represent the weather state
- The application will include the ability to force refresh and update to the latest forecast

## Developer Notes

### Server
https://localhost:5001
The .NET Core MVC application that works as a proxy to the REST Api and stores the forecast data in a local sqlite database. The forecast data is valid for a day (or until force refresh)

### Client
http://localhost:3000
The React application that fetches and renders the weather forecast data
- Uses [Bootstrap](https://getbootstrap.com/) for styling
- Uses [Auth0](https://auth0.com/) for authentication

### Running the application
- The server has automatic migrations and the database should be created on initial launch
- Upon first request to the server for weather forecast data it will query the api and save the forecast data into the database
- The client will communicate with my Auth0 credentials which are for testing purposes and are automatically wiped
- The credentials can be found in the .env folder in the client

![desktop-weather-forecast](https://user-images.githubusercontent.com/61074400/91235437-76bf1400-e72d-11ea-9c28-b2ab2064ad00.png)
![mobile-weather-forecast](https://user-images.githubusercontent.com/61074400/91235583-bb4aaf80-e72d-11ea-8ba1-2894cf1ac0dc.png)
