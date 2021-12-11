﻿using ISBAN.BestStories.Domain.Interfaces.ACL;
using ISBAN.BestStories.Domain.Interfaces.Service;
using ISBAN.BestStories.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISBAN.BestStories.Domain.Services
{
    public class StoryService : IStoryService
    {
        private readonly ILogger<StoryService> _logger;
        private readonly IHackerNewsAcl _hackerNewsAcl;
        public StoryService(ILogger<StoryService> logger, IHackerNewsAcl hackerNewsAcl)
        {
            _logger = logger;
            _hackerNewsAcl = hackerNewsAcl;
        }

        public async Task<List<Story>> GetBestTwenty()
        {
            var result = new List<Story>();
            Story story = null;

            _logger.LogInformation("Getting best stories.");
            var bestStories = await _hackerNewsAcl.GetBestStories();

            for (int index = 0; index <= 20; index++)
            {
                _logger.LogInformation($"Getting story {bestStories[index]} information.");
                story = await _hackerNewsAcl.GetStory(bestStories[index]);
                result.Add(story);
            }

            return result;
        }
    }
}