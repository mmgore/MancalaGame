using Microsoft.Extensions.Caching.Memory;
using System;

namespace Mangala.Application.Extensions
{
    public static class CacheExtensions
    {
        public const string KEY = "board";
        public static void SetCache<T>(this IMemoryCache _memoryCache, T entity)
        {
            if (!_memoryCache.TryGetValue(KEY, out T result))
            {
                var cacheExpirationOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = new TimeSpan(0, 30, 0),
                    Priority = CacheItemPriority.Normal
                };

                _memoryCache.Set(KEY, entity, cacheExpirationOptions);
            }
        }

        public static void RemoveCache(this IMemoryCache _memoryCache) 
            => _memoryCache.Remove(KEY);

       //public static   GetCache(this IMemoryCache _memoryCache)
       // {
       //     return _memoryCache.Get(KEY);
       // }
        
    }
}
