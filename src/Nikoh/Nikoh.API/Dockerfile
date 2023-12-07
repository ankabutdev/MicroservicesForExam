#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Nikoh/Nikoh.API/Nikoh.API.csproj", "src/Nikoh/Nikoh.API/"]
COPY ["src/Nikoh/Nikoh.Application/Nikoh.Application.csproj", "src/Nikoh/Nikoh.Application/"]
COPY ["src/Nikoh/NIkoh.Domain/NIkoh.Domain.csproj", "src/Nikoh/NIkoh.Domain/"]
COPY ["src/Nikoh/Nikoh.Infrastructure/Nikoh.Infrastructure.csproj", "src/Nikoh/Nikoh.Infrastructure/"]
RUN dotnet restore "./src/Nikoh/Nikoh.API/./Nikoh.API.csproj"
COPY . .
WORKDIR "/src/src/Nikoh/Nikoh.API"
RUN dotnet build "./Nikoh.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Nikoh.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nikoh.API.dll"]