# Buld:
#     docker build -t cs-api-demo-builder-image --file ./docker/local-builder.dockerfile .
# Start:
#     docker run -d --rm --name api-builder -v $PWD:/app -p 5001:5555 cs-api-demo-builder-image

FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

ENTRYPOINT ["bash", "/app/docker/local-run.sh"]
