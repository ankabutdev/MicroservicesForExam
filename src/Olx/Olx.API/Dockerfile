#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Olx/Olx.API/Olx.API.csproj", "src/Olx/Olx.API/"]
COPY ["src/Olx/Olx.Application/Olx.Application.csproj", "src/Olx/Olx.Application/"]
COPY ["src/Olx/Olx.Domain/Olx.Domain.csproj", "src/Olx/Olx.Domain/"]
COPY ["src/Olx/Olx.Infrastructure/Olx.Infrastructure.csproj", "src/Olx/Olx.Infrastructure/"]
RUN dotnet restore "./src/Olx/Olx.API/./Olx.API.csproj"
COPY . .
WORKDIR "/src/src/Olx/Olx.API"
RUN dotnet build "./Olx.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Olx.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Olx.API.dll"]