#!/usr/bin/env bash

# ASPNETCORE_ENVIRONMENT defines the app environment:
# Development, Staging, Production (default)
# @see /docker/local.docker-compose.json

PORT=5555
docker build -t cs-api-app-image --file ./docker/local.dockerfile .
docker-compose --file ./docker/local.docker-compose.json up -d
echo ""
echo ""
echo "********"
echo ""
echo "type 'run' to rebuild and start the app"
echo "your local machine is listening on port :"${PORT}
echo "press ^C to stop the app"
echo "type 'exit' to leave and destroy the container"
echo ""

docker exec -it cs-api-app ash

docker-compose --file ./docker/local.docker-compose.json stop
