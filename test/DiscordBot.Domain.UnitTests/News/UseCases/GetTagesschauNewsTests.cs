﻿using System;
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
        public async Task Should_Return_Correct_Number_Of_News()
        {
            var fixture = new Fixture();

            var generatedNews = fixture.CreateMany<NewsInternal>(20).ToList();

            _newsRepository.GetTagesschauNews().Returns(generatedNews);

            var parameters = new TagesschauParameters(10);

            var expectedNews = generatedNews.Take(parameters.Count);

            var actualNews = await _getTagesschauNews.Execute(parameters);

            actualNews.Should().NotBeNullOrEmpty();
            actualNews.Should().HaveCount(parameters.Count);
            actualNews.Should().BeEquivalentTo(expectedNews);
        }

        [Fact]
        public async Task Should_Return_As_Many_News_As_Possible_If_Selected_Number_Is_Higher()
        {
            var fixture = new Fixture();

            const int expectedNumberOfNews = 20;

            var generatedNews = fixture.CreateMany<NewsInternal>(expectedNumberOfNews).ToList();

            _newsRepository.GetTagesschauNews().Returns(generatedNews);

            var parameters = new TagesschauParameters(30);

            var expectedNews = generatedNews.Take(parameters.Count);

            var actualNews = await _getTagesschauNews.Execute(parameters);

            actualNews.Should().NotBeNullOrEmpty();
            actualNews.Should().HaveCount(expectedNumberOfNews);
            actualNews.Should().BeEquivalentTo(expectedNews);
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Count_Is_Less_Or_Equal_To_0()
        {
            var fixture = new Fixture();

            var generatedNews = fixture.CreateMany<NewsInternal>(20).ToList();

            _newsRepository.GetTagesschauNews().Returns(generatedNews);

            var parameters = new TagesschauParameters(0);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _getTagesschauNews.Execute(parameters));
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Returned_News_Are_Null()
        {
            _newsRepository.GetTagesschauNews().Returns((IEnumerable<NewsInternal>?) null);

            var parameters = new TagesschauParameters(20);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _getTagesschauNews.Execute(parameters));
        }
    }
}