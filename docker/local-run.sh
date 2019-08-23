#!/usr/bin/env ash

# create an alias for building and running the app
echo "alias run=\"dotnet publish /app/apidemo -c Debug --output /app/dist && dotnet /app/dist/apidemo.dll\"" >> /root/.ashrc
# apply the alias
. /root/.ashrc
# run the interactive shell
tail -f /dev/null
