using ISBAN.BestStories.Domain.Interfaces.ACL;
using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Text.Json;
using ISBAN.BestStories.Domain.Models;

namespace ISBAN.BestStories.Domain.ACL
{
    public class HackerNewsAcl : IHackerNewsAcl
    {
        private readonly string _baseUrl;
        private readonly string _bestStoriesPath;
        private readonly string _storyPath;
        public HackerNewsAcl(IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("HackerNewsAPI:BaseUrl").Value;
            _bestStoriesPath = configuration.GetSection("HackerNewsAPI:BestStoriesPath").Value;
            _storyPath = configuration.GetSection("HackerNewsAPI:StoryPath").Value;
        }

        public async Task<List<int>> GetBestStories()
        {
            var result = await _baseUrl.AppendPathSegment(_bestStoriesPath).GetStringAsync();

            return JsonSerializer.Deserialize<List<int>>(result);
        }

        public async Task<Story> GetStory(int storyId)
        {
            var result = await _baseUrl.AppendPathSegment(string.Format(_storyPath, storyId)).GetStringAsync();

            return JsonSerializer.Deserialize<Story>(result);
        }
    }
}
