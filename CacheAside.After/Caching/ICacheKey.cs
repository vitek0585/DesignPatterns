namespace CacheAside.After.Caching
{
    public interface ICacheKey<TItem>
    {
        string CacheKey { get; }
    }
}