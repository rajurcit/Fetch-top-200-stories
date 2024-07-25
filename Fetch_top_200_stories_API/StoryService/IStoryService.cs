using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryService
{
    
    public interface IStoryService
    {
        Task<string> GetStoryList();
    }
}
