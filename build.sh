#!/usr/bin/env bash

# builds a production image

rm -rf ./published/*
touch ./published/.gitkeep
docker build -t cs-demo-builder --file ./docker/prod-builder.dockerfile .
docker run --rm -v $PWD:/app cs-demo-builder
docker build -t cs-demo-prod --file ./docker/prod.dockerfile .
