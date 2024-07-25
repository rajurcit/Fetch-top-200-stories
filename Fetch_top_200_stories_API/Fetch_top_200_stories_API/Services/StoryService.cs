using Fetch_top_200_stories_API.Models;
using Fetch_top_200_stories_API.Repositories;
using StoryService;
using System.Data;

namespace Fetch_top_200_stories_API.Services
{
    public class StoryService1
    {
        private readonly IStoryService _storyService;

        public StoryService1(IStoryService storyService)
        {
            _storyService = storyService;
        }

        /// <summary>
        /// Get Story List
        /// </summary>
        /// <returns>return result</returns>
        public async Task<Result> GetStoryList()
        {
            Result res = new Result();

            try
            {
                string str = await _storyService.GetStoryList();
                if (!string.IsNullOrEmpty(str))
                {
                    res.Data = str;
                    res.Success = true;
                    res.StatusCode = 200;
                    res.UserMsg = "Data retrieved successfully!!";
                }
                else
                {
                    res.Success = false;
                    res.UserMsg = "Data not retrieved.";
                    res.StatusCode = 400;
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.UserMsg = ex.Message;
                res.StatusCode = 500;
                return res;
            }
        }
    }
}
