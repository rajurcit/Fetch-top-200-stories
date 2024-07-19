using Fetch_top_200_stories_API.Models;
using Fetch_top_200_stories_API.Repositories;
using System.Data;

namespace Fetch_top_200_stories_API.Services
{
    public class StoryService
    {
        StoryRepository repo = new StoryRepository();
        public async Task<Result> GetStoryList()
        {
            Result res = new Result();

            try
            {
                string str = await repo.GetStoryList(); // Make asynchronous call
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
