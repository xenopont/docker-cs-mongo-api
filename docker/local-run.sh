#!/usr/bin/env bash

# create an alias for building and running the app
echo "alias run=\"dotnet publish /app/apidemo -c Debug --output /app/dist && dotnet /app/dist/apidemo.dll\"" >> ~/.bashrc
# apply the alias
. ~/.bashrc
# run the interactive shell
bash
