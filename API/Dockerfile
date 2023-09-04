#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["microservice-teste-bemobi.API/microservice-teste-bemobi.API.csproj", "microservice-teste-bemobi.API/"]
RUN dotnet restore "microservice-teste-bemobi.API/microservice-teste-bemobi.API.csproj"
COPY . .
WORKDIR "/src/microservice-teste-bemobi.API"
RUN dotnet build "microservice-teste-bemobi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "microservice-teste-bemobi.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "microservice-teste-bemobi.API.dll"]