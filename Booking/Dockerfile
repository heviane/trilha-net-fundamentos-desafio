# Stage 1: Build
# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files to restore dependencies
# Copying them separately leverages Docker's layer caching.
# The build context is expected to be the repository root.
COPY ["trilha-net-fundamentos-desafio.sln", "."]
COPY ["Booking/Booking.csproj", "Booking/"]
COPY ["Booking.Tests/Booking.Tests.csproj", "Booking.Tests/"]
COPY ["Parking/Parking.csproj", "Parking/"]
COPY ["Parking.Tests/Parking.Tests.csproj", "Parking.Tests/"]

# Restore dependencies for the entire solution
RUN dotnet restore "trilha-net-fundamentos-desafio.sln"

# Copy the rest of the source code into the container
COPY . .

# Set the working directory to the project folder and publish
WORKDIR "/src/Booking"
RUN dotnet publish "Booking.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Run
# Use the .NET runtime image for the final, smaller image
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Booking.dll"]
