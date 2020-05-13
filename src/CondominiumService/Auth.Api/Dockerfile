#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ENV APP_HOME /src
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY ["Auth.Api/*.csproj", "$APP_HOME/Auth.Api/"]
RUN cd $APP_HOME/Auth.Api && dotnet restore

COPY ["Auth.Api", "$APP_HOME/Auth.Api/"]
RUN cd $APP_HOME/Auth.Api && dotnet build

FROM build AS publish
WORKDIR $APP_HOME/Auth.Api
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.Api.dll"]