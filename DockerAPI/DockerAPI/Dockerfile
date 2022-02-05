# Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore 

# Copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image 
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

# From here 
# https://github.com/dotnet/SqlClient/issues/220
# and here 
# https://github.com/dotnet/SqlClient/issues/220
# is explainde wha I should use code on lines 22 and 25
# Install cultures (same approach as Alpine SDK image)
RUN apk add --no-cache icu-libs

# Disable the invariant mode (set in base image)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","DockerAPI.dll"]
