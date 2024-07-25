namespace Fetch_top_200_stories_API.Models
{
    public class Result
    {
        public Result(object data = null, int statusCode = 200, bool success = false, string userMsg = "", string sysMsg = "")
        {
            Data = data;
            StatusCode = statusCode;
            Success = success;
            UserMsg = userMsg;            
        }
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }        
        public string UserMsg { get; set; }
    }
}
