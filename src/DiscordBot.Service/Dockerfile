#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/DiscordBot.Service/DiscordBot.Service.csproj", "src/DiscordBot.Service/"]
COPY ["src/DiscordBot.Core.Constants/DiscordBot.Core.Constants.csproj", "src/DiscordBot.Core.Constants/"]
COPY ["src/DiscordBot.Commands/DiscordBot.Commands.csproj", "src/DiscordBot.Commands/"]
COPY ["src/DiscordBot.Dragonball.Domain/DiscordBot.Dragonball.Domain.csproj", "src/DiscordBot.Dragonball.Domain/"]
COPY ["src/Discordbot.Core/Discordbot.Core.csproj", "src/Discordbot.Core/"]
COPY ["src/DiscordBot.WatchTogether.Domain/DiscordBot.WatchTogether.Domain.csproj", "src/DiscordBot.WatchTogether.Domain/"]
COPY ["src/DiscordBot.Dice.Domain/DiscordBot.Dice.Domain.csproj", "src/DiscordBot.Dice.Domain/"]
COPY ["src/Discordbot.Memes.Domain/Discordbot.Memes.Domain.csproj", "src/Discordbot.Memes.Domain/"]
COPY ["src/Discordbot.WatchTogether.Data/Discordbot.WatchTogether.Data.csproj", "src/Discordbot.WatchTogether.Data/"]
COPY ["src/DiscordBot.Core.Requests/DiscordBot.Core.Data.csproj", "src/DiscordBot.Core.Requests/"]
COPY ["src/DiscordBot.Memes.Data/DiscordBot.Memes.Data.csproj", "src/DiscordBot.Memes.Data/"]
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