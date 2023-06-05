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
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/usecases-diagram.png" alt=Clean Architecture Use Cases" style="max-width:100%;">  
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

To run via debug in Visual Studio:
```To run via debug in Visual Studio
Set the docker-compose project as "Set as Startup Project" and press F5 (Starting Debugging).
```

<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/docker-compose-startup.png" alt=Docker Compose Startup Project" style="max-width:100%;">  
</p>
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/docker-compose-run.png" alt=Docker Compose Run" style="max-width:100%;">  
</p>
                                                                                                                                                      

To run via CMD:
``` To run via CMD
docker-compose  -f "docker-compose.yml" -f "docker-compose.override.yml" up --build -d
```
                                                                        
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/docker-compose-cmd.png" alt=Docker Compose Run" style="max-width:100%;">  
</p>


Then the following containers should be running on `docker ps`:
| Application 	      | URL                                                                           |
|-------------------- | ----------------------------------------------------------------------------- |
| Web API 	          | https://localhost:5002/index.html                                          |
| PostgreSQL 	      | "Host=currency-exchange-trades-database;Port=5432;Database=postgres;User Id=postgres;Password=postgres;" |


Swagger:
```Swagger
http://localhost:5001/index.html     
https://localhost:5002/index.html     
```

# Highlights

Clean Architecture
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/CleanArchitecture.png" alt=CleanArchitecture" style="max-width:100%;">  
</p>


CQRS - (EF Core + Dapper)
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/CQRS.png" alt=CQRS" style="max-width:100%;">  
</p>


CQRS
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/CQRS.png" alt=CQRS" style="max-width:100%;">  
</p>


FluentValidation
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/FluentValidation.png" alt=FluentValidation" style="max-width:100%;">  
</p>


FluentValidation
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/FluentValidation.png" alt=FluentValidation" style="max-width:100%;">  
</p>


Unit Tests with XUnit
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/UnitTests.png" alt=UnitTests" style="max-width:100%;">  
</p>


Swagger
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/swagger.png" alt=swagger" style="max-width:100%;">  
</p>


Service with MemoryCache
<p align="center">  
  <img src="https://github.com/jhonnatan/CurrencyExchangeTrades/blob/main/docs/MemoryCache.png" alt=MemoryCache" style="max-width:100%;">  
</p>


