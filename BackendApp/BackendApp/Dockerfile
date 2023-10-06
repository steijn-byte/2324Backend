# Use the official .NET 6 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj file and restore NuGet packages
COPY BackendApp/BackendApp/BackendApp.csproj BackendApp/
RUN dotnet restore BackendApp/BackendApp.csproj

# Copy the entire project and build
COPY BackendApp/ BackendApp/
WORKDIR /app/BackendApp
RUN dotnet publish -c Release -o out

# Use a lighter base image for the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/BackendApp/out .

# Expose the port that the application will listen on
EXPOSE 80
EXPOSE 443

# Set the entry point for the application
ENTRYPOINT ["dotnet", "BackendApp.dll"]
