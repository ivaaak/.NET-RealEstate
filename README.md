# .NET - Real Estate API
A Web API built with .NET 7, Microservices, MediatR/CQRS Pattern, EF Core, and using Clean Architecture. Data stores: PostgreSQL (Mongo?), Redis.
It can be used for listing, browsing and renting/selling properties. 


### Architecture (planned):


		┌────────────────────────────────────┐
		│             API Gateway:           │
          ┌───────│  Identity, Auth0/JWT, Rate Limit   │───────┐   
          │       └────┬────────────┬────────────┬─────┘       │
	      │            │            │            │             │   
      ┌───┴───┐    ┌───┴───┐    ┌───┴───┐    ┌───┴───┐    ┌────┴────┐  
      │Estates│    │Listing│    │ Client│    │ Utils │    │ Payments│    Microservices     
      └───┬───┘    └───┬───┘    └───┬───┘    └───┬───┘    └────┬────┘
      ┌───┴───┐    ┌───┴───┐    ┌───┴───┐    ┌───┴───┐    ┌────┴────┐  
      │Postgre│    │Postgre│    │ Mongo │    │ Redis │    │ Ext API │  Data - Database / External API
      └───┬───┘    └───┬───┘    └───┬───┘    └───┬───┘    └────┬────┘
          │            │            │            │             │
	      │       ┌────┴────────────┴────────────┴────┐        │
	      └───────│       RabbitMQ  / MassTransit     │────────┘  
	              │     Event Bus / Transport Layer   │  Producer / Consumer
	              └─────────────────┬─────────────────┘


## Built With:
- [**✔**]  .NET  7 
-  [**✔**]  Microservices
-  [**✔**]  Ocelot - API Gateway
-  Camunda - Orchestration
-  [**✔**]  Auth:  .NET Identity System, Auth0, JWT 
-  [**✔**]  MediatR / CQRS Pattern
-  [**✔**]  ORM - Entity Framework Core 6
-  [**✔**]  PostgreSQL
-  [**✔**]  Redis Caching
-  Event Bus - RabbitMQ / MassTransit
-  [**✔**]  Docker - Microservices and DBs Containerization
-  [**✔**]  Fluent Validation
-  A Scraper which takes listings from real sites
-  SignalR for on-page notifications/messaging
-  [**✔**]  Sendgrid for emails
-  Cloudinary.Net for file upload/storage
-  [**✔**]  Polly - Persistance/Retries
-  [**✔**]  HangFire for task scheduling / background execution
-  Automapper
-  [**✔**]  Swagger / Swashbuckle
-  [**✔**]  Stripe Payments API
-  Algolia / Elasticsearch
-  ELK stack for logging - Elasticsearch / Logstash / Kibana

(Testing)
- MyTested.AspNetCore.Mvc 
- Moq (incl inMemory DB)
- xunit and NUnit
- coverlet / CodeCov


#### Roles :  Guest, User, Agent, Admin

Features I intend to implement:

- Auth0  (Authorization using the standard JWT middleware)
- Build/Configure a cralwer to copy listings from a real site/dataset
- SignalR for on-page notifications/messaging
- Sendgrid for emails
- Cloudinary.Net for file upload/storage
- Polly Persistance/Retries
