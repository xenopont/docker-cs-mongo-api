# docker build -t cs-demo-prod --file ./docker/prod.dockerfile .
# docker run -d --rm --name cs-demo-prod -p 8081:5555 --add-host mongo:172.17.0.3 cs-demo-prod

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9 as runtime
COPY published /app
ENTRYPOINT ["dotnet", "/app/apidemo.dll"]
