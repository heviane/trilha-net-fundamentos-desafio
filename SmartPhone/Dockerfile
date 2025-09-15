# Stage 1: Build
# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files to restore dependencies
# Copy all source code. This is much simpler to mainr
#tPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartPhone.dll"]
