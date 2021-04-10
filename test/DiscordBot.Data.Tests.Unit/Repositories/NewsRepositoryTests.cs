using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Data.DataSources.Local.News;
using DiscordBot.Data.DataSources.Remote.News;
using DiscordBot.Data.Repositories;
using DiscordBot.Domain.Entities;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Data.Tests.Unit.Repositories
{
    public class NewsRepositoryTests
    {
        private readonly INewsLocalCacheDataSource _newsLocalCacheDataSource;

        private readonly NewsRepository _sut;
        private readonly ITagesschauRemoteDataSource _tagesschauRemoteDataSource;

        public NewsRepositoryTests()
        {
            _newsLocalCacheDataSource = Substitute.For<INewsLocalCacheDataSource>();
            _tagesschauRemoteDataSource = Substitute.For<ITagesschauRemoteDataSource>();

            _sut = new NewsRepository(_tagesschauRemoteDataSource, _newsLocalCacheDataSource);
        }

        [Fact]
        public async Task GetTagesschauNewsSavesNewsInCacheAndReturnsThemIfNoCacheIsPresent()
        {
            var fixture = new Fixture();

            var expectedNews = fixture.CreateMany<NewsInternal>(10).ToList();

            _newsLocalCacheDataSource.Get(Arg.Any<string>()).Returns(Task.FromResult<List<NewsInternal>>(null));

            _tagesschauRemoteDataSource.GetTagesschauNews(Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(expectedNews));

            var actualNews = await _sut.GetTagesschauNews();

            actualNews.Should().BeEquivalentTo(expectedNews);

            await _newsLocalCacheDataSource.Received(1).Set(Arg.Any<string>(), expectedNews);
        }

        [Fact]
        public async Task GetTagesschauNewsReturnsFromCacheIfAnyValueIsPresent()
        {
            var fixture = new Fixture();

            var expectedNews = fixture.CreateMany<NewsInternal>(10).ToList();

            _newsLocalCacheDataSource.Get(Arg.Any<string>()).Returns(Task.FromResult(expectedNews));

            var actualNews = await _sut.GetTagesschauNews();

            actualNews.Should().BeEquivalentTo(expectedNews);

            await _newsLocalCacheDataSource.Received(1).Get(Arg.Any<string>());
            await _tagesschauRemoteDataSource.Received(0).GetTagesschauNews(Arg.Any<CancellationToken>());
        }
    }
}