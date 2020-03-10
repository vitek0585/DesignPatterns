namespace CacheAside.After.Caching
{
    public class UserInfoCacheKey : ICacheKey<UserInfo>
    {
        private readonly int _userId;
        public UserInfoCacheKey(int userId)
        {
            _userId = userId;
        }

        public string CacheKey => $"UserId_{this._userId}";
    }
}