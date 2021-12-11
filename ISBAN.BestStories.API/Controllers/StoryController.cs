using ISBAN.BestStories.API.Filters;
using ISBAN.BestStories.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISBAN.BestStories.API.Controllers
{
    [TypeFilter(typeof(CustomExceptionFilter))]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        [Route("best20")]
        public async Task<IActionResult> GetBestTwenty()
        {
            var result = await _storyService.GetBestTwenty();

            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
