# .NET - Real Estate API
A Web API built with .NET 7, Microservices, MediatR/CQRS Pattern, EF Core, and using Clean Architecture. Data stores: PostgreSQL (Mongo?), Redis.
It can be used for listing, browsing and renting/selling properties. 

## Frontend: [RealEstate Frontend](https://github.com/ivaaak/RealEstate-Frontend)
### Architecture (planned):

![.](https://github.com/ivaaak/.NET-RealEstate/blob/main/RealEstate.ApiGateway/RealEstateAPI-Architecture-light.png#gh-dark-mode-only)![.](https://github.com/ivaaak/.NET-RealEstate/blob/main/RealEstate.ApiGateway/RealEstateAPI-Architecture.png#gh-light-mode-only)

#### [API Gateway :9000](https://github.com/ivaaak/.NET-RealEstate/tree/main/RealEstate.ApiGateway) - Routing, Auth/Authz, Load Balancer, CORS, Rate Limiter, Health Checks, Swagger

#### [Clients Microservice :9001](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ClientsMicroservice) - Client profiles, Roles, Saved Items/Settings

#### [Contracts Microservice :9002](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ContractsMicroservice) -  Contracts - Save, Modify Documents

#### [Estates Microservice :9003](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/EstatesMicroservice) - Estates Management, Data Access

#### [External APIs :9004](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ExternalAPIsMicroservice) - Zillow API, Stripe API, Scraper

#### [ListingsMicroservice :9005](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ListingsMicroservice) - Estate Listings, Search, Filter, Trends

#### [MessagingMicroservice :9006](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/MessagingMicroservice) - Emails, Notifications 

#### [UtilitiesMicroservice :9007](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/UtilitiesMicroservice) - Background Tasks, File Management, Cache, Formatters, Shared Resources

#### [Cross-Cutting Concerns / Shared](https://github.com/ivaaak/.NET-RealEstate/tree/main/RealEstate.Shared) - Generic Repository, Event Bus, Logging, MediatR, Models - Entities, DTOs, Startup Extensions


### Built With:
-  [**✔**]  `.NET  7`
-  [**✔**]  `Microservices` (and Clean Architecture)
-  [**✔**]  `Vertical Slice Architecture`
-  [**✔**]  `Domain Driven Design (DDD)` to implement all business processes in microservices.
-  [**✔**]  `Fluent Validation` and a `Validation Pipeline Behaviour` on top of `MediatR`.
-  [**✔**]  `Built-In Containerization` for `Docker` images of microservices and DBs
-  [**✔**]  `Ocelot` - API Gateway/Reverse Proxy 
-  [**✔**]  `MediatR` / CQRS Pattern
-  [**✔**]  `Entity Framework Core 6` - ORM
-  [**✔**]  `PostgreSQL` (and MongoDB possibly?)
-  [**✔**]  `Redis` Caching
-  [**✔**]  `Sendgrid` for emails
-  [**✔**]  `Cloudinary.Net` for file upload/storage
-  [**✔**]  `Swagger` / Swashbuckle API Docs
-  [**✔**]  `Stripe` Payments API
-  [**✔**]  `Elasticsearch / Logstash / Kibana` - ELK stack for logging
-  [**✔**]  `Automapper`
-  [**✔**]  `Nuke` Build Pipeline
-  [**✔**]  `Keycloak` - Authentication / Authorization and User Management


#### Not implemented yet / In Progress:
-  A Scraper which takes listings from real sites
-  `RabbitMQ / MassTransit` - Event Bus
-  `SignalR` for on-page notifications/messaging
-  `Polly` Resilience - Persistance/Retries
-  `HangFire` for task scheduling / background execution
-  `CI/CD Pipeline` with github actions
-  `Consul` - Service Discovery
-  `Grafana + Prometheus` - Monitoring
-  `CodeCov` - Code Coverage and Reports
-  `SonarAnalyzer + StyleCop` - Code quality gate
-  `Sieve` - Sorting and Filtering
-  `Spectre Console`
-  `Zipkin` - distributed tracing


#### Future plans:
-  `Camunda` - Orchestration and BPMN Engine
-  `Aggregator service` for fetching from multiple DBs
-  `Token Handler Middleware` which is used for the Keycloak Auth
-  `MVC Versioning API` 
-  `opentelemetry-dotnet`


(Testing)
- MyTested.AspNetCore.Mvc 
- Moq (incl inMemory DB)
- xunit and NUnit
- coverlet / CodeCov

#### Roles :  Guest, User, Agent, Admin
