using ISBAN.BestStories.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISBAN.BestStories.Domain.Interfaces.ACL
{
    public interface IHackerNewsAcl
    {
        Task<List<int>> GetBestStories();
        Task<Story> GetStory(int storyId);
    }
}
