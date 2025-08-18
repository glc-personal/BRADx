FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InstrumentControlWebApi/InstrumentControlWebApi.csproj", "InstrumentControlWebApi/"]
RUN dotnet restore "InstrumentControlWebApi/InstrumentControlWebApi.csproj"
COPY . .
WORKDIR "/src/InstrumentControlWebApi"
RUN dotnet build "InstrumentControlWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InstrumentControlWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstrumentControlWebApi.dll"]
