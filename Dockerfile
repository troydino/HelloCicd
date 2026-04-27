# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY HelloCicd.slnx .
COPY HelloCicd.Api/HelloCicd.Api.csproj HelloCicd.Api/
COPY HelloCicd.Tests/HelloCicd.Tests.csproj HelloCicd.Tests/

RUN dotnet restore

COPY . .

RUN dotnet test --no-restore --verbosity minimal

RUN dotnet publish HelloCicd.Api/HelloCicd.Api.csproj \
    --no-restore \
    -c Release \
    -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

<<<<<<< HEAD
ARG APP_ENVIRONMENT=Docker
ENV AppEnvironment=$APP_ENVIRONMENT

USER app

COPY --from=build --chown=app /app/publish .
=======
RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

COPY --from=build /app/publish .
>>>>>>> ab34715 (Add Dockerfile, .dockerignore and CI pipeline)

EXPOSE 8080

ENTRYPOINT ["dotnet", "HelloCicd.Api.dll"]