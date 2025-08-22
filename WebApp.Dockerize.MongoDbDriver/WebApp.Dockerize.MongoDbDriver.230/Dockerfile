# Use the official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["WebApp.Dockerize.MongoDbDriver.230.csproj", "."]
RUN dotnet restore "WebApp.Dockerize.MongoDbDriver.230.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "WebApp.Dockerize.MongoDbDriver.230.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "WebApp.Dockerize.MongoDbDriver.230.csproj" -c Release -o /app/publish

# Use the official .NET 8 runtime image for final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Create a non-root user
RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

# Copy the published application
COPY --from=publish /app/publish .

# Expose port
EXPOSE 5259

ENTRYPOINT ["dotnet", "WebApp.Dockerize.MongoDbDriver.230.dll"]
