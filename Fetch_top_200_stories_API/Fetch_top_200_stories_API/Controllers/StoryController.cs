using Fetch_top_200_stories_API.Models;
using Fetch_top_200_stories_API.Services;
using Fetch_top_200_stories_API.Utilities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;

namespace Fetch_top_200_stories_API.Controllers
{
    public class StoryController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ISerilogLogger _serilogger;

        public StoryController(IMemoryCache memoryCache, ISerilogLogger serilogger)
        {
            _memoryCache = memoryCache;
            _serilogger = serilogger;
        }

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
                    StoryService ser = new StoryService();
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
            catch (Exception ex)
            {
                Log.Error($"Error in GetStoryList Task API is {JsonConvert.SerializeObject(ex)}");
                res.Success = false;
                res.UserMsg = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, res);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
