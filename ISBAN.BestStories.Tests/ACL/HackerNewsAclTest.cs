using AutoFixture;
using FluentAssertions;
using Flurl.Http.Testing;
using ISBAN.BestStories.Domain.ACL;
using ISBAN.BestStories.Domain.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ISBAN.BestStories.Tests.ACL
{
    class HackerNewsAclTest
    {
        private HackerNewsAcl _acl;
        private Mock<IConfiguration> _config;

        HttpTest _http;
        Fixture _fixture;
        [SetUp]
        public void Setup()
        {
            _http = new HttpTest();
            _config = new Mock<IConfiguration>();
            _fixture = new Fixture();

            _config.Setup(x => x.GetSection("HackerNewsAPI:BaseUrl").Value).Returns("http://test.com");
            _config.Setup(x => x.GetSection("HackerNewsAPI:BestStoriesPath").Value).Returns("/testPath");
            _config.Setup(x => x.GetSection("HackerNewsAPI:StoryPath").Value).Returns("/testPath");

            _acl = new HackerNewsAcl(_config.Object);
        }

        [Test]
        public async Task ShouldGetBestStoriesSuccessfully()
        {
            var response = _fixture.CreateMany<int>(30);

            _http.RespondWithJson(response, 200);

            var result = await _acl.GetBestStories();

            result.Should().HaveCount(30);
        }

        [Test]
        public async Task ShouldGetStoryByIdSuccessfully()
        {
            var id = _fixture.Create<int>();
            var story = _fixture.Create<Story>();
            var response = JsonSerializer.Serialize(story);

            _http.RespondWith(response, 200);

            var result = await _acl.GetStory(id);

            result.Should().NotBeNull();
        }
    }
}
