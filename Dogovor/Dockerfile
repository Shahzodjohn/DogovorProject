#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dogovor/Dogovor.csproj", "Dogovor/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["ConnectionProvider/ConnectionProvider.csproj", "ConnectionProvider/"]
COPY ["Entity/Entity.csproj", "Entity/"]
RUN dotnet restore "Dogovor/Dogovor.csproj"
COPY . .
WORKDIR "/src/Dogovor"
RUN dotnet build "Dogovor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dogovor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dogovor.dll"]
