# C# Demo Web API

## Docker Development Environment

### builder

The docker image file for the builder is located in: `/docker/local-builder.dockerfile`

building an image:
```bash
docker build -t cs-api-demo-builder-image --file ./docker/local-builder.dockerfile .
```

running the builder container:
```bash
docker run -d --rm --name api-builder -v $PWD:/app -p 5001:5555 cs-api-demo-builder-image
```

creating an empty web api app:
```bash
docker exec -it api-builder dotnet new webapi --name apidemo
```

build the project:
```bash
docker exec -it api-builder dotnet publish ./apidemo -c Debug --output ../dist
```

run the api
```bash
docker exec -it api-builder dotnet ./dist/apidemo.dll
```
Listening port is configured in `/apidemo/Program.cs` in the line `UseUrls()`

rebuild and run
```bash
docker exec -it api-builder dotnet publish ./apidemo -c Debug --output ../dist && dotnet ./dist/apidemo.dll
```

## Mongo thing

driver:
https://github.com/mongodb/mongo-csharp-driver

add (in the .csproj file)
```xml
<ItemGroup>
    <PackageReference Include="MongoDb.Driver" Version="2.7.2" />
</ItemGroup>
```
to enable MongoDB.Driver and other namespaces in the project
