using StoryService;

namespace StoryServiceData
{

    public class StoryService : IStoryService
    {
        /// <summary>
        /// Get Story List
        /// </summary>
        /// <returns>return list of string json</returns>
        public async Task<string> GetStoryList()
        {
            var content = string.Empty;
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

            catch (Exception)
            {
                throw;
            }

            return content;
        }
 
    }
}
