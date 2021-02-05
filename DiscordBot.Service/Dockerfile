#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DiscordBot.Service/DiscordBot.Service.csproj", "DiscordBot.Service/"]
COPY ["DiscordBot.Commands/DiscordBot.Commands.csproj", "DiscordBot.Commands/"]
COPY ["DiscordBot.Dragonball.Domain/DiscordBot.Dragonball.Domain.csproj", "DiscordBot.Dragonball.Domain/"]
COPY ["Discordbot.Core/Discordbot.Core.csproj", "Discordbot.Core/"]
COPY ["DiscordBot.Dice.Domain/DiscordBot.Dice.Domain.csproj", "DiscordBot.Dice.Domain/"]
RUN dotnet restore "DiscordBot.Service/DiscordBot.Service.csproj"
COPY . .
WORKDIR "/src/DiscordBot.Service"
RUN dotnet build "DiscordBot.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordBot.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordBot.Service.dll"]