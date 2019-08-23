FROM mcr.microsoft.com/dotnet/core/runtime:2.2.6-alpine3.9 as runtime
WORKDIR /app
COPY published/apidemo.dll ./
ENTRYPOINT ["dotnet", "apidemo.dll"]
