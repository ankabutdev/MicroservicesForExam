#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/GameClub/GameClub.API/GameClub.API.csproj", "src/GameClub/GameClub.API/"]
COPY ["src/GameClub/GameClub.Application/GameClub.Application.csproj", "src/GameClub/GameClub.Application/"]
COPY ["src/GameClub/GameClub.Domain/GameClub.Domain.csproj", "src/GameClub/GameClub.Domain/"]
COPY ["src/GameClub/GameClub.Infrastructure/GameClub.Infrastructure.csproj", "src/GameClub/GameClub.Infrastructure/"]
RUN dotnet restore "./src/GameClub/GameClub.API/./GameClub.API.csproj"
COPY . .
WORKDIR "/src/src/GameClub/GameClub.API"
RUN dotnet build "./GameClub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GameClub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameClub.API.dll"]