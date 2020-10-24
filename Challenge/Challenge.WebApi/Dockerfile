#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Challenge.WebApi/Challenge.WebApi.csproj", "Challenge.WebApi/"]
RUN dotnet restore "Challenge.WebApi/Challenge.WebApi.csproj"
COPY . .
WORKDIR "/src/Challenge.WebApi"
RUN dotnet build "Challenge.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Challenge.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challenge.WebApi.dll"]
