FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env



WORKDIR /Ap
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore collect-calculator.query-api/collect-calculator.query-api.csproj
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /Ap/out .

ENTRYPOINT ["dotnet", "collect-calculator.query-api.dll"]
