FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app

ENTRYPOINT ["ash", "/app/docker/local-run.sh"]
