FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env



WORKDIR /Ap
RUN apk --verbose --no-cache add curl iputils

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore collect-api-gateway-api/collect-api-gateway.csproj
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /App

COPY --from=build-env /Ap/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "collect-api-gateway.dll"]