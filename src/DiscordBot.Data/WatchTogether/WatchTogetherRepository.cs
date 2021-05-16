﻿using System.Threading.Tasks;
using DiscordBot.Data.WatchTogether.DataSources;
using DiscordBot.Domain.WatchTogether.Entities;
using DiscordBot.Domain.WatchTogether.Repositories;

namespace DiscordBot.Data.WatchTogether
{
    internal class WatchTogetherRepository : IWatchTogetherRepository
    {
        private readonly IWatchTogetherRemoteDataSource _watchTogetherRemoteDataSource;

        public WatchTogetherRepository(IWatchTogetherRemoteDataSource watchTogetherRemoteDataSource)
        {
            _watchTogetherRemoteDataSource = watchTogetherRemoteDataSource;
        }

        public async Task<CreatedRoom> CreateWatchTogetherRoom(string? youtubeLink = null)
        {
            return await _watchTogetherRemoteDataSource.CreateWatchTogetherRoom(youtubeLink);
        }
    }
}