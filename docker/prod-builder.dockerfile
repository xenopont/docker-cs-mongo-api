# docker build -t cs-demo-builder --file ./docker/prod-builder.dockerfile .
# docker run --rm -v $PWD:/app cs-demo-builder

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
ENTRYPOINT ["dotnet", "publish", "/app/apidemo", "-c", "Release", "--output", "/app/published"]
