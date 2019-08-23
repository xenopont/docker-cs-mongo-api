FROM mcr.microsoft.com/dotnet/core/sdk:2.2.6-alpine3.9 AS build-env
WORKDIR /app
ENTRYPOINT ["dotnet", "publish", "-c", "Release", "-o", "published"]