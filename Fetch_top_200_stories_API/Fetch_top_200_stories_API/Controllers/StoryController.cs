using Fetch_top_200_stories_API.Models;
using Fetch_top_200_stories_API.Services;
using Fetch_top_200_stories_API.Utilities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;
using StoryService;
using StoryServiceData;

namespace Fetch_top_200_stories_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ISerilogLogger _serilogger;
        private readonly IStoryService _storyService;

        public StoryController(IMemoryCache memoryCache, ISerilogLogger serilogger, IStoryService storyService)
        {
            _memoryCache = memoryCache;
            _serilogger = serilogger;
            _storyService = storyService;
        }

        /// <summary>
        /// Get Story List
        /// </summary>
        /// <returns>return list of story in json string</returns>
        [HttpGet]
        [Route("GetStoryList")]
        public async Task<ActionResult> GetStoryList()
        {
            Result res = new Result();
            try
            {
                string cacheKey = $"StoryInfo";
                Log.Debug($"GetStoryList API request");

                if (!_memoryCache.TryGetValue(cacheKey, out Result cachedResult))
                {
                    StoryService1 ser = new StoryService1(_storyService);
                    res = await ser.GetStoryList();

                    _memoryCache.Set(cacheKey, res, TimeSpan.FromMinutes(5));

                    cachedResult = res; // Assign res to cachedResult for return
                }
                else
                {
                    // Use cachedResult directly if it exists
                    res = cachedResult;
                }

                return StatusCode(cachedResult.StatusCode, cachedResult);

            }
            catch (HttpRequestException httpEx)
            {
                Log.Error($"HTTP request error in GetStoryList: {httpEx.Message}", httpEx);
                res.Success = false;
                res.UserMsg = "There was an error retrieving the story list.";
                res.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return StatusCode(StatusCodes.Status503ServiceUnavailable, res);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GetStoryList API: {JsonConvert.SerializeObject(ex)}", ex);
                res.Success = false;
                res.UserMsg = "An unexpected error occurred.";
                res.StatusCode = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, res);
            }
            finally
            {
                await Log.CloseAndFlushAsync(); // Ensure logging operations are awaited
            }
        }
    }
}
