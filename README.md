# Alumni .NET Case Project - Backend
## About the project

The Alumni Project is the case period project for the Noroff Accelerate .NET program. This repository contains the backend solution of the project. 

The project is a RESTful API service which makes it possible to interact with the database regarding users, posts, topics, groups and events.

## Installation
Requirements:
- SQL Express
- Visual Studio (.NET 6)

#### In Visual studio the NUGET packages needed are:
```
AutoMapper.extensions.Microsoft.DepencyInjection (12.0.0)
Microsoft.AspNetCore.Authentication.JwtBearer (6.0.9)
Microsoft.EntityFrameworkCore.Design (6.0.9)
Microsoft.EntityFrameworkCore.SqlServer  (6.0.9)
Microsoft.EntityFrameworkCore.Tools  (6.0.9)
Newtonsoft.Json (13.0.1)
Swashbuckle.AspNetCore (6.2.3)
```

To start the project locally it is required to have the secret IssuerUI and KeyURI for keycloak identification to run any endpoints.
#### Before local run:
```
In Package Manager Console:
update-database
```
## User manual and API Documentation
[User Manual](PATH) 
[API Documentation](PATH) 
## Contributors
| Name | Linkedin |
| ------ | ------ |
| Fredrik Fauskanger | https://linkedin.com/in/fredrik-fauskanger-a63056147 |
| Ole Martin Gjerde | - |
| Sondre Fjelde | https://linkedin.com/in/sondre-fjelde-6a045a215 |
| Espen Sjo | https://linkedin.com/in/espen-sjo-72aaa7236 |
