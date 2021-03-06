#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DockerApp.csproj", ""]
RUN dotnet restore "./DockerApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DockerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT "dotnet ef migrations add Initial"
ENTRYPOINT "dotnet ef database update"
ENTRYPOINT ["dotnet", "DockerApp.dll"]