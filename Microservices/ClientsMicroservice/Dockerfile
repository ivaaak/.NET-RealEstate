#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Microservices/ClientsMicroservice/ClientsMicroservice.csproj", "Microservices/ClientsMicroservice/"]
COPY ["RealEstate.ApiGateway/RealEstate.ApiGateway.csproj", "RealEstate.ApiGateway/"]
COPY ["RealEstate.Shared/RealEstate.Shared.csproj", "RealEstate.Shared/"]
RUN dotnet restore "Microservices/ClientsMicroservice/ClientsMicroservice.csproj"
COPY . .
WORKDIR "/src/Microservices/ClientsMicroservice"
RUN dotnet build "ClientsMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientsMicroservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientsMicroservice.dll"]