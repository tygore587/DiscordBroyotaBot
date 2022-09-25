#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/DiscordBot.Api/DiscordBot.Api.csproj", "src/DiscordBot.Api/"]
COPY ["src/DiscordBot.Data/DiscordBot.Data.csproj", "src/DiscordBot.Data/"]
COPY ["src/DiscordBot.Domain/DiscordBot.Domain.csproj", "src/DiscordBot.Domain/"]
COPY ["src/DiscordBot.Core/DiscordBot.Core.csproj", "src/DiscordBot.Core/"]
COPY ["src/DiscordBot.Core.Domain/DiscordBot.Core.Domain.csproj", "src/DiscordBot.Core.Domain/"]
COPY ["src/DiscordBot.Core.Constants/DiscordBot.Core.Constants.csproj", "src/DiscordBot.Core.Constants/"]
COPY ["src/DiscordBot.Core.Data/DiscordBot.Core.Data.csproj", "src/DiscordBot.Core.Data/"]
RUN dotnet restore "src/DiscordBot.Api/DiscordBot.Api.csproj"
COPY . .
WORKDIR "/src/src/DiscordBot.Api"
RUN dotnet build "DiscordBot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordBot.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordBot.Api.dll"]