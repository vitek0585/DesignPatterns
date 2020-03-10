using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CacheAside.Before.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public UsersController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("{userId:int}")]
        public ActionResult<UserInfo> Get(int userId)
        {
            UserInfo userInfo;

            if (!this._memoryCache.TryGetValue($"UserInfo_{userId}", out userInfo))
            {
                userInfo = this.GetFromDatabase(userId);

                this._memoryCache.Set($"UserInfo_{userId}", userInfo, new TimeSpan(0, 5, 0));
            }

            return userInfo;
        }

        private UserInfo GetFromDatabase(int userId) => new UserInfo();
    }
}
