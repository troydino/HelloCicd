# HelloCicd

A minimal .NET 10 Web API demonstrating a production-quality CI/CD pipeline.

![CI](https://github.com/troydino/HelloCicd/actions/workflows/ci.yml/badge.svg)
![CD](https://github.com/troydino/HelloCicd/actions/workflows/cd.yml/badge.svg)
[![Coverage Status](https://coveralls.io/repos/github/troydino/HelloCicd/badge.svg?branch=main)](https://coveralls.io/github/troydino/HelloCicd?branch=main)

## Stack

- **.NET 10** Web API
- **Docker** — multi-stage build with non-root user
- **GitHub Actions** — CI/CD pipeline
- **GHCR** — GitHub Container Registry
- **Render** — free tier hosting
- **Coveralls** — code coverage reporting

## Architecture

~~~
HelloCicd/
├── HelloCicd.Api/
│   ├── Controllers/    # Thin HTTP layer
│   ├── Services/       # Business logic
│   └── Models/         # Response models
└── HelloCicd.Tests/
    ├── Controllers/    # Integration tests
    └── Services/       # Unit tests
~~~

## Pipeline

~~~
PR opened → CI (build + test + coverage report)
Merge to main → CD (build image → push to GHCR → deploy to Render)
~~~

## API

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/hello` | Returns a hello world message with version and timestamp |

## Local Development

~~~bash
dotnet build
dotnet test
dotnet run --project HelloCicd.Api
~~~