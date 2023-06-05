# Solution
A bank’s micro-service that offer currency exchange functionality, such as:

• Integrating to a rate provider to get real-time exchange rate
• Retaining information about currency exchange trades
• When an exchange rate is used it should never be older than 30 minutes
• Each client can only create 10 currency exchange trades per hour

# Motivation
Designing modular applications is the holy grail of software architecture and is quite hard to find applications which allows adding new features in a steady speed.

# Use Cases
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/docs/usecases-diagram.png" alt=Clean Architecture Use Cases" style="max-width:100%;">  
</p>

Following the list of Use Cases:

| Use Case                      | Description                                                           |
|-------------------------------|-----------------------------------------------------------------------|
| Get Exchange Rates            | Return real-time exchange rates from one currency base.               |
| Simulate Exchange Trade       | Simulate currency exchange trades.                                    |
| Create Exchange Trade         | Register currency exchange trades carried out by its clients.         |
| Get Exchange Trade By Id      | Get a currency exchange trade by id.                                  |
| Get Exchange Trades By Client | Get currency exchange trades by client.                               |

# Technologies
• .NET Core Web API
• Swagger
• Docker
• PostgreSQL
• Entity Framework Core
• Dapper
• Autofac
• Caching
• FluentValidation

# Architecture Styles
• Clean Architecture
• RESTful APIs

# Design Patterns and Good Practices
• CQRS
• SOLID
• Chain of Responsability
• Builder
• Presenter
• Repository
• Unit Tests

# Instructions
```To run via debug in Visual Studio
Set the docker-compose project as "Set as Startup Project" and press F5 (Starting Debugging).
```

<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/docs/docker-compose-startup.png" alt=Docker Compose Startup Project" style="max-width:100%;">  
</p>
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/docs/docker-compose-run.png" alt=Docker Compose Run" style="max-width:100%;">  
</p>

```To run via CMD
docker-compose  -f "docker-compose.yml" -f "docker-compose.override.yml" up -d
```
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/docs/docker-compose-cmd.png" alt=Docker Compose Run" style="max-width:100%;">  
</p>

Then the following containers should be running on `docker ps`:
| Application 	      | URL                                                                           |
|-------------------- | ----------------------------------------------------------------------------- |
| Web API 	          | https://localhost:5002/index.html                                          |
| PostgreSQL 	      | "Host=currency-exchange-trades-database;Port=5432;Database=postgres;User Id=postgres;Password=postgres;" |


```Swagger
http://localhost:5001/index.html     
https://localhost:5002/index.html     
```