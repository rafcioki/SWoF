# Support Wheel of Fate

## How to use the application
The application is hosted under https://rota-swof.azurewebsites.net/. If a schedule doesn't exist a user sees a window allowing to create a new schedule. It requires to provide an end date up to which the schedule is built. After creating a schedule it is displayed as a list. It's possible to delete a schedule by clicking "Delete" button at the bottom of the list.

## Frontend
Built using [React](https://reactjs.org/) on top of [create-react-app](https://github.com/facebook/create-react-app).
### Setting up locally
Node >= 6 and npm 6+ (or yarn 0.25+) are required to install.

To run it locally install packages (*npm install* or *yarn install*), then the app can be started by running *npm start* or *yarn start*

Make sure to set the right API path under *src/Config.json*

## Backend
Built using .NET Core 2.1, WebApi and Entity Framework Core.

### Setting up locally
Set the right connection string in appsettings.json. WebApi project should create and migrate database on first start.

## Hosting
Application is hosted on Azure.
* Frontend is deployed as Web App
* API is deployed as Web App
* Database is deployed as SQL Database

API's app service uses free plan, which means it'll go idle after some time of inactivitiy, so the first API call might take some time.
