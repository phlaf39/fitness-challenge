FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FitnessLeaderboard.Api/FitnessLeaderboard.Api.csproj", "FitnessLeaderboard.Api/"]
COPY ["FitnessLeaderboard.Data/FitnessLeaderboard.Data.csproj", "FitnessLeaderboard.Data/"]
COPY ["FitnessLeaderboard.Domain/FitnessLeaderboard.Domain.csproj", "FitnessLeaderboard.Domain/"]
RUN dotnet restore "FitnessLeaderboard.Api/FitnessLeaderboard.Api.csproj"
COPY . .
WORKDIR "/src/FitnessLeaderboard.Api"
RUN dotnet build "FitnessLeaderboard.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FitnessLeaderboard.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessLeaderboard.Api.dll"]