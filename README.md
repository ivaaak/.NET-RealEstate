# .NET - Real Estate API
A Web API built with .NET 7, Microservices, MediatR/CQRS Pattern, EF Core, and using Clean Architecture. Data stores: PostgreSQL (Mongo?), Redis.
It can be used for listing, browsing and renting/selling properties. 

## Frontend: [RealEstate Frontend](https://github.com/ivaaak/RealEstate-Frontend)
### Architecture (planned):

![.](https://github.com/ivaaak/.NET-RealEstate/blob/main/RealEstate.ApiGateway/RealEstateAPI-Architecture-light.png#gh-dark-mode-only)![.](https://github.com/ivaaak/.NET-RealEstate/blob/main/RealEstate.ApiGateway/RealEstateAPI-Architecture.png#gh-light-mode-only)

## Microservice, Build Status (GitHub Actions), Description:
| Microservice | Status | Description |
| ------------- | ------------- | ------------- |
| [API Gateway :9000](https://github.com/ivaaak/.NET-RealEstate/tree/main/RealEstate.ApiGateway) | [![api-gateway](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api-gateway.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api-gateway.yml) | Routing, Auth/Authz, Load Balancer, CORS, Rate Limiter, Health Checks, Swagger |
|[Clients :9001](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ClientsMicroservice)| [![api.clients](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.clients.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.clients.yml) | Client profiles, Roles, Saved Items/Settings |
| [Contracts :9002](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ContractsMicroservice)| [![api.contracts](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.contracts.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.contracts.yml)| Contracts - Save, Modify Documents |
| [Estates :9003](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/EstatesMicroservice)| [![api.estates](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.estates.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.estates.yml) | Estates Management, Data Access |
| [External API :9004](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ExternalAPIsMicroservice)| [![api.external](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.external.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.external.yml) | Zillow API, Stripe API, Scraper |
| [Listings :9005](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ListingsMicroservice)| [![api.listings](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.listings.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.listings.yml) | Estate Listings, Search, Filter, Trends |
| [Messaging :9006](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/MessagingMicroservice)| [![api.messaging](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.messaging.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.messaging.yml) | Emails, Notifications |
| [Utilities :9007](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/UtilitiesMicroservice)| [![api.utilities](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.utilities.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/api.utilities.yml) | Background Tasks, File Management, Cache, Formatters, Shared Resources |
| [Cross-Cutting / Shared](https://github.com/ivaaak/.NET-RealEstate/tree/main/RealEstate.Shared)| [![shared](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/shared.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/shared.yml) | Generic Repository, Event Bus, Logging, MediatR, Models - Entities, DTOs, Startup Extensions |
| [Tests](https://github.com/ivaaak/.NET-RealEstate/tree/main/RealEstate.Test) | [![test-unit](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/test-unit.yml/badge.svg)](https://github.com/ivaaak/.NET-RealEstate/actions/workflows/test-unit.yml) | e2e, Functional. Integration, Unit Tests |
### Getting Started
Make sure you have [installed](https://docs.docker.com/docker-for-windows/install/) and [configured](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Windows-setup#configure-docker) docker in your environment. After that, you can run the below commands from the **.NET RealEstate** directory and start the project:

```cmd
docker-compose build
docker-compose up
```

```make
make compose-build
make compose
```

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
-  [**✔**]  `Elasticsearch / Logstash|Serilog / Kibana` - ELK stack for logging
-  [**✔**]  `Automapper` 
-  [**✔**]  `Nuke` Build Pipeline
-  [**✔**]  `Keycloak` - Authentication / Authorization and User Management
-  [**✔**]  `RabbitMQ / MassTransit` - Event Bus
-  [**✔**]  `CI/CD Pipeline` with github actions
-  [**✔**]  `Polly` Resilience - Persistance/Retries
-  [**✔**]  `SonarAnalyzer + StyleCop` - Code quality gate
-  [**✔**]  `CodeCov` - Code Coverage and Reports


#### Not implemented yet / In Progress:
-  A Scraper which takes listings from real sites
-  `HangFire` for task scheduling / background execution
-  `Consul` - Service Discovery
-  `Grafana + Prometheus` - Monitoring
-  `Sieve` - Sorting and Filtering
-  `Spectre Console`
-  `Zipkin` - distributed tracing
-  `SignalR` for on-page notifications/messaging


#### Future plans:
-  `Camunda` - Orchestration and BPMN Engine
-  `Aggregator service` - Data from multiple DBs / Microservices and transformations
-  `Token Handler Middleware` which is used for the Keycloak Auth
-  `MVC Versioning API` 
-  `opentelemetry-dotnet`


(Testing)
- MyTested.AspNetCore.Mvc 
- Moq (incl inMemory DB)
- xunit and NUnit
- coverlet / CodeCov

#### Roles :  Guest, User, Agent, Admin (Editable in the Keycloak client)

#### Services / Utilities and where to find them:
| Service: | Where to find it: | Description |
| ------------- | ------------- | ------------- |
| API Gateway Swagger | http://localhost:9000/swagger/index.html | Swagger pages for all microservices |
| Microservice openapi.json | http://localhost:900X/swagger/v1/swagger.json | OpenAPI config for each service |
| Microservice Swagger UI: | http://localhost:900X/swagger/index.html | Swagger interface for each service |
| Keycloak Dashboard | http://localhost:8080/ | Keycloak UI for managing Users, Roles, Realms |
| RabbitMQ Dashboard | http://localhost:15672/#/ | RabbitMQ UI for visualising queues/buses |
| PgAdmin | http://localhost:5050/browser/ | In-Browser DB management |
| Elasticsearch | http://localhost:9200/ | Elasticsearch instance config |
| Kibana | http://localhost:5601/ | Kibana UI for elasticsearch/logging |
