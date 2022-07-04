#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RealEstate.Api/RealEstate.Api.csproj", "RealEstate.Api/"]
RUN dotnet restore "RealEstate.Api/RealEstate.Api.csproj"
COPY . .
WORKDIR "/src/RealEstate.Api"
RUN dotnet build "RealEstate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstate.Api.dll"]