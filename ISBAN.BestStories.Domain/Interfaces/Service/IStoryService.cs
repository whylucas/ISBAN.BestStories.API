using ISBAN.BestStories.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISBAN.BestStories.Domain.Interfaces.Service
{
    public interface IStoryService
    {
        Task<List<Story>> GetBestTwenty();
    }
}
