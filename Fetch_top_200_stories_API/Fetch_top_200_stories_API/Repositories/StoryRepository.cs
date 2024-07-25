using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;

namespace Fetch_top_200_stories_API.Repositories
{
    public class StoryRepository
    {
        /// <summary>
        /// Get Story List
        /// </summary>
        /// <returns>return list of string json</returns>
        public async Task<string> GetStoryList()
        {
            var content = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://hacker-news.firebaseio.com/v0/item/8863.json?print=pretty";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        content = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
            return content;
        }
    }
}
