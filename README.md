# investment-option-calculator

This is a practice of full stack web application project which is created with

    1. React & Typescript
    2. React Redux
    3. .Net 5 Restful API（C#）
    4. Exchang Rate service (3nd party API)

The goal of this App is attempt to allow user to select investment options and check the investment return with fees.

Architecture design: SOLID / Microservices / OOD(Object Oriented Design) / CQRS(Command Query Responsibility Segregation) / DDD(Domain Driven Design)

Front End: React 17 with React Material, React Redux, React Router, Typescript...

There are two key components in React client:

"login" component: - Supporting user to get authentication (JWT token) by username & password. - JWT token will be saved into Redux Store. JWT token will be added into http request header for each API request. - UI will be navigated to "calculator" page after login

"calculator" component: - Allow user to setup investment amount - Allow user to select investment options - Allow user to check investment return and fees

Back End: .Net 5, RESTful API with clean architecture

There are two key controllers in Dotnet API:
"AuthController": - Generate JWT token for user authentication
"CalculatorController": - Supporting investment calculations and providing Exchange Rate service to convert AUD to USD (ExchangeRate API Key is stored in appsettings.Development.json) NOTE: current API Key can't support the conversion from ExchangeRatesAPI (Getting error message: "Access Restricted - Your current Subscription Plan does not support this API Function."), replace the valid API Key in appsettings.json will make it work (It might needs to join paid subscription plan).

There are two microservices/domains in backend:
"Calculator": - Supporting create notes command & user notes query - Save/Query notes from local MonogoDB
"Customers": - <to do> allow user signup and create new customer data in DB - <to do> support user login and authentication. A test user data is hard coded for now.

App start command:

    Front end:
        1. run "npm install" in "react-Client"
        2. run "npm start" in "react-Client" (React has been proxy to localhost:8080)
    Back end:
        build and run from "DotNetCleanArchitecture/DotNetCleanArchitecture.API/bin/Debug/net5.0/DotNetCleanArchitecture.API.dll"
        (If you are using VSC, it is already been setup in .vscode)

Open browser at localhost:3000 and login by:
username: test
password: test

To Do: user authentication with Customer service / front end e2e test & unit test/ API testing / .Net unit test

Future: This app can be easily scale up to support more use cases with different microservices and UI ( even mobile App )

Personal Info: https://www.linkedin.com/in/wayne-hong-456131a2/
