FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN useradd -m appuser 
USER appuser
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Calculator ./Calculator
COPY API ./API
COPY Tests ./Tests
WORKDIR /src/API
RUN dotnet restore
RUN dotnet build "API.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "API.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
USER appuser
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
