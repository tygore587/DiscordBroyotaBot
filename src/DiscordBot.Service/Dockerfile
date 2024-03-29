#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/DiscordBot.Service/DiscordBot.Service.csproj", "src/DiscordBot.Service/"]
COPY ["src/DiscordBot.Commands/DiscordBot.Commands.csproj", "src/DiscordBot.Commands/"]
COPY ["src/DiscordBot.Core/DiscordBot.Core.csproj", "src/DiscordBot.Core/"]
COPY ["src/DiscordBot.Domain/DiscordBot.Domain.csproj", "src/DiscordBot.Domain/"]
COPY ["src/DiscordBot.Core.Domain/DiscordBot.Core.Domain.csproj", "src/DiscordBot.Core.Domain/"]
COPY ["src/DiscordBot.Data/DiscordBot.Data.csproj", "src/DiscordBot.Data/"]
COPY ["src/DiscordBot.Core.Data/DiscordBot.Core.Data.csproj", "src/DiscordBot.Core.Data/"]
RUN dotnet restore "src/DiscordBot.Service/DiscordBot.Service.csproj"
COPY . .
WORKDIR "/src/src/DiscordBot.Service"
RUN dotnet build "DiscordBot.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordBot.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordBot.Service.dll"]