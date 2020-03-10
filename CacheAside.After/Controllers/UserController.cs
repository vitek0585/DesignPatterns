using CacheAside.After.Caching;
using Microsoft.AspNetCore.Mvc;

namespace CacheAside.After.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users2Controller : ControllerBase
    {
        private readonly ICacheStore _cacheStore;

        public Users2Controller(ICacheStore cacheStore)
        {
            _cacheStore = cacheStore;
        }

        [HttpGet]
        [Route("{userId:int}")]
        public ActionResult<UserInfo> Get(int userId)
        {
            var userInfoCacheKey = new UserInfoCacheKey(userId);
            UserInfo userInfo = this._cacheStore.Get(userInfoCacheKey);

            if (userInfo == null)
            {
                userInfo = this.GetFromDatabase(userId);

                this._cacheStore.Add(userInfo, userInfoCacheKey, expirationTime: null);
            }

            return userInfo;
        }

        private UserInfo GetFromDatabase(int userId) => new UserInfo();
    }
}
