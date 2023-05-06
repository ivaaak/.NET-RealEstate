# .NET - Real Estate API
A Web API built with .NET 7, Microservices, MediatR/CQRS Pattern, EF Core, and using Clean Architecture. Data stores: PostgreSQL (Mongo?), Redis.
It can be used for listing, browsing and renting/selling properties. 

## Frontend: [RealEstate Frontend](https://github.com/ivaaak/RealEstate-Frontend)
### Architecture (planned):

![.](./RealEstate.ApiGateway/RealEstateAPI-Architecture.png#gh-dark-mode-only)
![.](./RealEstate.ApiGateway/RealEstateAPI-Architecture-light.png#gh-light-mode-only)


#### [Clients Microservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ClientsMicroservice) - Identity, Client profiles, Roles

#### [ListingsMicroservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ListingsMicroservice) - Estate Listings, Search, Filter, Trends

#### [Estates Microservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/EstatesMicroservice) - Estates Management, Data Access

#### [Contracts Microservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ContractsMicroservice) -  Contracts - Save, Modify Documents

#### [UtilitiesMicroservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/UtilitiesMicroservice) - Background Tasks, File Management, Cache, Formatters

#### [MessagingMicroservice](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/MessagingMicroservice) - Emails, Notifications 

#### [External APIs](https://github.com/ivaaak/.NET-RealEstate/tree/main/Microservices/ExternalAPIsMicroservice) - Zillow API, Stripe API, Scraper


### Built With:
- [**✔**]  .NET  7 
-  [**✔**]  Microservices (Clean Architecture)
-  [**✔**]  API Gateway/Reverse Proxy - Ocelot
-  [**✔**]  MediatR / CQRS Pattern
-  [**✔**]  ORM - Entity Framework Core 6
-  [**✔**]  PostgreSQL (and MongoDB possibly?)
-  [**✔**]  Redis Caching
-  [**✔**]  Docker - Microservices and DBs Containerization
-  [**✔**]  Sendgrid for emails
-  [**✔**]  Cloudinary.Net for file upload/storage
-  [**✔**]  Swagger / Swashbuckle API Docs
-  [**✔**]  Stripe Payments API
-  [**✔**]  ELK stack for logging - Elasticsearch / Logstash / Kibana
-  [**✔**]  Automapper
-  [**✔**]  Nuke Build Pipeline

#### Not implemented yet / In Progress:
-  Auth / User Management:  Keycloak + a Token Handler
-  Fluent Validation
-  A Scraper which takes listings from real sites
-  Event Bus - RabbitMQ / MassTransit
-  SignalR for on-page notifications/messaging
-  Resilience - Polly - Persistance/Retries
-  HangFire for task scheduling / background execution
-  CI/CD Pipeline with github actions

#### Future plans:
-  Camunda - Orchestration Engine
-  Consul - Service Discovery
-  An Aggregator service for fetching from multiple DBs
-  Token Handler Middleware which is used for the Keycloak Auth
-  Monitoring -  Grafana + Prometheus
-  Code Coverage and Reports - CodeCov

(Testing)
- MyTested.AspNetCore.Mvc 
- Moq (incl inMemory DB)
- xunit and NUnit
- coverlet / CodeCov

#### Roles :  Guest, User, Agent, Admin

