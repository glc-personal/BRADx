FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InstrumentControlService/InstrumentControlService.csproj", "InstrumentControlService/"]
RUN dotnet restore "InstrumentControlService/InstrumentControlService.csproj"
COPY . .
WORKDIR "/src/InstrumentControlService"
RUN dotnet build "InstrumentControlService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InstrumentControlService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstrumentControlService.dll"]