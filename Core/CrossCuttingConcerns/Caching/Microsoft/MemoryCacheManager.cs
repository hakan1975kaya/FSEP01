﻿using Core.Utilities.Service;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheService
    {
        private IMemoryCache _cache;
        public MemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _cache.Set(key, value, TimeSpan.FromMinutes(duration));
        }
        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }
        public object Get(string key)
        {
            return _cache.Get(key);
        }
        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;

            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            if (cacheEntriesCollection != null)
            {
                foreach (var cacheItem in cacheEntriesCollection)
                {

                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);

                    cacheCollectionValues.Add(cacheItemValue);
                }
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            if (keysToRemove != null)
            {
                if (keysToRemove.Count > 0)
                {
                    foreach (var keyToRemove in keysToRemove)
                    {
                        _cache.Remove(keyToRemove);
                    }
                }
            }
        }











    }
}
