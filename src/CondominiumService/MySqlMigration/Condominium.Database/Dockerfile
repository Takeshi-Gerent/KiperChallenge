#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MySqlMigration/Condominium.Database/Condominium.Database.csproj", "MySqlMigration/Condominium.Database/"]
COPY ["Condominium.Core/Condominium.Core.csproj", "Condominium.Core/"]
COPY ["Auth.Api/Auth.Api.csproj", "Auth.Api/"]
RUN dotnet restore "MySqlMigration/Condominium.Database/Condominium.Database.csproj"
COPY . .
WORKDIR "/src/MySqlMigration/Condominium.Database"
RUN dotnet build "Condominium.Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Condominium.Database.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Condominium.Database.dll"]