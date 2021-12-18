using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using DiscordBot.Domain.News.Entities;
using DiscordBot.Domain.News.Repositories;
using DiscordBot.Domain.News.UseCases;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DiscordBot.Domain.UnitTests.News.UseCases
{
    public class GetTagesschauNewsTests
    {
        private readonly GetTagesschauNews _getTagesschauNews;
        private readonly INewsRepository _newsRepository;

        public GetTagesschauNewsTests()
        {
            _newsRepository = Substitute.For<INewsRepository>();
            _getTagesschauNews = new GetTagesschauNews(_newsRepository);
        }


        [Fact]
        public async Task ShouldReturnCorrectNumberOfNews()
        {
            var fixture = new Fixture();

            var generatedNews = fixture.CreateMany<NewsEntity>(20).ToList();

            _newsRepository.GetTagesschauNews().Returns(generatedNews);

            var parameters = new TagesschauParameters(10);

            var expectedNews = generatedNews.Take(parameters.Count);

            var actualNews = await _getTagesschauNews.Execute(parameters);

            actualNews.Should().NotBeNullOrEmpty();
            actualNews.Should().HaveCount(parameters.Count);
            actualNews.Should().BeEquivalentTo(expectedNews);
        }

        [Fact]
        public async Task ShouldReturnAsManyNewsAsPossibleIfSelectedNumberIsHigher()
        {
            var fixture = new Fixture();

            const int expectedNumberOfNews = 20;

            var generatedNews = fixture.CreateMany<NewsEntity>(expectedNumberOfNews).ToList();

            _newsRepository.GetTagesschauNews().Returns(generatedNews);

            var parameters = new TagesschauParameters(30);

            var expectedNews = generatedNews.Take(parameters.Count);

            var actualNews = await _getTagesschauNews.Execute(parameters);

            actualNews.Should().NotBeNullOrEmpty();
            actualNews.Should().HaveCount(expectedNumberOfNews);
            actualNews.Should().BeEquivalentTo(expectedNews);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfCountIsLessOrEqualTo0()
        {
            var fixture = new Fixture();

            var generatedNews = fixture.CreateMany<NewsEntity>(20).ToList();

            _newsRepository.GetTagesschauNews().Returns(generatedNews);

            var parameters = new TagesschauParameters(0);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _getTagesschauNews.Execute(parameters));
        }

        [Fact]
        public async Task ShouldThrowExceptionIfReturnedNewsAreNull()
        {
            _newsRepository.GetTagesschauNews().Returns((IEnumerable<NewsEntity>?) null);

            var parameters = new TagesschauParameters(20);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _getTagesschauNews.Execute(parameters));
        }
    }
}