using ISBAN.BestStories.Domain.ACL;
using ISBAN.BestStories.Domain.Interfaces.ACL;
using ISBAN.BestStories.Domain.Interfaces.Service;
using ISBAN.BestStories.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ISBAN.BestStories.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApiInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IHackerNewsAcl, HackerNewsAcl>();
            return services;
        }
    }
}
