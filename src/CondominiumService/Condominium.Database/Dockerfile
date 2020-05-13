#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ENV APP_HOME /src
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY ["Condominium.Core/Condominium.Core.csproj", "$APP_HOME/Condominium.Core/"]
COPY ["Auth.Api/Auth.Api.csproj", "$APP_HOME/Auth.Api/"]
COPY ["Condominium.Database/Condominium.Database.csproj", "$APP_HOME/Condominium.Database/"]
RUN cd $APP_HOME/Condominium.Database && dotnet restore

COPY ["Condominium.Core", "$APP_HOME/Condominium.Core/"]
COPY ["Auth.Api", "$APP_HOME/Auth.Api/"]
COPY ["Condominium.Database", "$APP_HOME/Condominium.Database/"]
RUN cd $APP_HOME/Condominium.Database && dotnet build

FROM build AS publish
WORKDIR $APP_HOME/Condominium.Database
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Condominium.Database.dll"]