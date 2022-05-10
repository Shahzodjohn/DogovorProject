FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
WORKDIR /app/Dogovor

# Copy everything else and build
#COPY . .
WORKDIR /app/Dogovor
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/Dogovor

COPY --from=build-env /app/Dogovor/out .
ENTRYPOINT ["dotnet", "Dogovor.dll","--urls=0.0.0.0:5145"]