# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY PaySmartly.Calculations/*.csproj ./PaySmartly.Calculations/
COPY PaySmartly.Calculations.Tests/*.csproj ./PaySmartly.Calculations.Tests/
RUN dotnet restore

# copy everything else and build app
COPY PaySmartly.Calculations/. ./PaySmartly.Calculations/
COPY PaySmartly.Calculations.Tests/. ./PaySmartly.Calculations.Tests/
WORKDIR /source/PaySmartly.Calculations
RUN dotnet publish -c release -o /PaySmartly.Calculations --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

LABEL author="Stefan Bozov"

WORKDIR /PaySmartly.Calculations
COPY --from=build /PaySmartly.Calculations ./
ENTRYPOINT ["dotnet", "PaySmartly.Calculations.dll"]