using AutoFixture;
using FluentAssertions;
using ISBAN.BestStories.Domain.Interfaces.ACL;
using ISBAN.BestStories.Domain.Interfaces.Service;
using ISBAN.BestStories.Domain.Models;
using ISBAN.BestStories.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISBAN.BestStories.Tests
{
    public class StoryServiceTest
    {
        private StoryService _service;
        private Mock<ILogger<StoryService>> _logger;
        private Mock<IHackerNewsAcl> _acl;

        Fixture _fixture;
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<StoryService>>();
            _acl = new Mock<IHackerNewsAcl>();
            _fixture = new Fixture();

            _service = new StoryService(_logger.Object, _acl.Object);
        }

        [Test]
        public async Task ShouldGetBestTwentyStoriesSuccessfully()
        {
            var storyList = _fixture.CreateMany<int>(30);
            var story = _fixture.Create<Story>();

            _acl.Setup(x => x.GetBestStories()).ReturnsAsync(new List<int>(storyList));
            _acl.Setup(x => x.GetStory(It.IsAny<int>())).ReturnsAsync(story);

            var result = await _service.GetBestTwenty();

            result.Should().HaveCount(20);
        }

        [Test]
        public async Task ShouldGetBestLessThenTwentyStoriesSuccessfully()
        {
            var storyList = _fixture.CreateMany<int>(18);
            var story = _fixture.Create<Story>();

            _acl.Setup(x => x.GetBestStories()).ReturnsAsync(new List<int>(storyList));
            _acl.Setup(x => x.GetStory(It.IsAny<int>())).ReturnsAsync(story);

            var result = await _service.GetBestTwenty();

            result.Should().HaveCount(18);
        }

        [Test]
        public async Task ShouldThrowErrorOnGettingBestStories()
        {
            var storyList = _fixture.CreateMany<int>(30);
            var story = _fixture.Create<Story>();

            _acl.Setup(x => x.GetBestStories()).Throws(new Exception());

            _service.Invoking(x => x.GetBestTwenty()).Should().ThrowAsync<Exception>();

        }
    }
}