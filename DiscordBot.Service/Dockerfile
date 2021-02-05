#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["DiscordBot.Core/DiscordBot.Core.csproj", "DiscordBot.Core/"]
COPY ["DiscordBot.Commands.Dragonball/DiscordBot.Commands.Dragonball.csproj", "DiscordBot.Commands.Dragonball/"]
COPY ["DiscordBot.Commands/DiscordBot.Commands.csproj", "DiscordBot.Commands/"]
RUN dotnet restore "DiscordBot.Core/DiscordBot.Core.csproj"
COPY . .
WORKDIR "/src/DiscordBot.Core"
RUN dotnet build "DiscordBot.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordBot.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY Procfile .
ENTRYPOINT ["dotnet", "DiscordBot.Core.dll"]