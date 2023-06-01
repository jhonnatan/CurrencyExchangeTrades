# Problem
In a bid to shift from a monolith to micro-service architecture, the bank has earmarked the currency exchange functionality as a suitable module to build the first micro-service. The micro-service has to offer the same functionality that currently exists in the bank’s solution, such as:

• Integrating to a rate provider to obtain the latest currency exchange rates. (Example https://fixer.io/ or https://exchangeratesapi.io/)

• Retaining information about currency exchange trades carried out by its clients

• When an exchange rate is used it should never be older than 30 minutes (Bonus question)

• Limiting each client to 10 currency exchange trades per hour (Bonus question)


# Instructions
In your solution you are expected to make use of (but not limited to):

• C# (.NET Core 3.1 or higher)

• Entity Framework Core

• Database of your choice

• Caching

• RESTful APIs

• Unit Tests

• Logging
