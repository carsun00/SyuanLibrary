using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace MemoryCacheLib.Controller
{
    /// <summary>
    ///     This Class onle process Set and Get.
    ///     if need verification data. should define in call Class layer.
    ///     
    ///     只處理設定與取值。
    ///     如果要驗證是否有資料應該在呼叫類別中。
    /// </summary>
    public class MemoryCacheTools
    {
        /// <summary>
        ///     InterFace
        /// </summary>
        private IMemoryCache Cache;

        /// <summary>
        ///     Set cache option . 
        ///     
        ///     設定快取屬性
        /// </summary>
        public MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            Priority = CacheItemPriority.Normal
        };

        /// <summary>
        ///     initial MemoryCache.
        /// </summary>
        /// <param name="MemoryCache">IMemoryCache</param>
        /// <code>
        /// //  初始化記憶體服務(DI)
        /// var provider = new ServiceCollection()
        ///             .AddMemoryCache()
        ///             .BuildServiceProvider();
        /// var cache = provider.GetService<IMemoryCache>();
        ///     
        /// MemoryCacheTools cacheTools = new MemoryCacheTools(cache);
        /// </code>
        public MemoryCacheTools(IMemoryCache MemoryCache)
        {
            Cache = MemoryCache;
        }

        /// <summary>
        ///     Set Memory Cache generic list.
        ///     寫入記憶體快取List<typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">ClassName</typeparam>
        /// <param name="cacheKeys">Cache Key</param>
        /// <param name="ListModel">List Data</param>
        public void SetMemoryList<T>(string cacheKeys, List<T> ListModel)
        {
            Cache.Set(cacheKeys, ListModel);
        }

        /// <summary>
        ///     Set Memory Cache key and value.
        ///     寫入記憶體Key and Value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKeys">Cache Key</param>
        /// <param name="ListModel">List Data</param>
        public void SetMemory<T>(string cacheKeys, T Data)
        {
            Cache.Set(cacheKeys, Data, cacheEntryOptions);
        }

        /// <summary>
        ///     Get single value by key.
        ///     使用關鍵字取得取得單一值。
        /// </summary>
        /// <param name="cacheKeys"></param>
        /// <returns>object</returns>
        public object GetMemoryData(string cacheKeys)
        {
            return Cache.Get(cacheKeys);
        }

        /// <summary>
        ///     Get List Data
        ///     取得List資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKeys"></param>
        /// <param name="ListModel"></param>
        /// <returns></returns>
        /// <code>
        /// List<T> DataInCache = new List<T>();
        /// DataInCache = cacheTools.GetMemoryList(CacheKeys.Name, DataInCache);
        /// </code>
        public List<T> GetMemoryList<T>(string cacheKeys, List<T> ListModel)
        {
            ListModel = (List<T>)Cache.Get(cacheKeys);
            return ListModel;
        }
    }
}
