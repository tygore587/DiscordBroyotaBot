#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/DiscordBot.Service/DiscordBot.Service.csproj", "src/DiscordBot.Service/"]
COPY ["src/DiscordBot.Core.Constants/DiscordBot.Core.Constants.csproj", "src/DiscordBot.Core.Constants/"]
COPY ["DiscordBot.Data/DiscordBot.Data.csproj", "DiscordBot.Data/"]
COPY ["src/DiscordBot.Domain/DiscordBot.Domain.csproj", "src/DiscordBot.Domain/"]
COPY ["src/Discordbot.Core.Domain/Discordbot.Core.Domain.csproj", "src/Discordbot.Core.Domain/"]
COPY ["src/DiscordBot.Commands/DiscordBot.Commands.csproj", "src/DiscordBot.Commands/"]
RUN dotnet restore "src/DiscordBot.Service/DiscordBot.Service.csproj"
COPY . .
WORKDIR "/src/src/DiscordBot.Service"
RUN dotnet build "DiscordBot.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordBot.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordBot.Service.dll"]