#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Kindergarten/Kindergarten.API/Kindergarten.API.csproj", "src/Kindergarten/Kindergarten.API/"]
COPY ["src/Kindergarten/Kindergarten.Application/Kindergarten.Application.csproj", "src/Kindergarten/Kindergarten.Application/"]
COPY ["src/Kindergarten/Kindergarten.Domain/Kindergarten.Domain.csproj", "src/Kindergarten/Kindergarten.Domain/"]
COPY ["src/Kindergarten/Kindergarten.Infrastructure/Kindergarten.Infrastructure.csproj", "src/Kindergarten/Kindergarten.Infrastructure/"]
RUN dotnet restore "./src/Kindergarten/Kindergarten.API/./Kindergarten.API.csproj"
COPY . .
WORKDIR "/src/src/Kindergarten/Kindergarten.API"
RUN dotnet build "./Kindergarten.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kindergarten.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kindergarten.API.dll"]