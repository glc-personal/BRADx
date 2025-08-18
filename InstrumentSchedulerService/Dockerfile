FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InstrumentSchedulerService/InstrumentSchedulerService.csproj", "InstrumentSchedulerService/"]
RUN dotnet restore "InstrumentSchedulerService/InstrumentSchedulerService.csproj"
COPY . .
WORKDIR "/src/InstrumentSchedulerService"
RUN dotnet build "InstrumentSchedulerService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InstrumentSchedulerService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstrumentSchedulerService.dll"]
