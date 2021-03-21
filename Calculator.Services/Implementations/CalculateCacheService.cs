using Calculator.Constants;
using Calculator.Extensions;
using Calculator.Services.Interfaces;
using Calculator.Types;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Services.Implementations
{
    public class CalculateCacheService : ICalculateCacheService
    {
        private readonly IMemoryCache _memoryCache;
        public CalculateCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IEnumerable<string> GetCacheValue(string key)
        {
            if (_memoryCache.TryGetValue(key, out IEnumerable<string> collection))
            {
                return collection;
            }
            else if (_memoryCache.TryGetValue(key, out string value))
            {
                return new List<string> { value };
            }

            return Enumerable.Empty<string>();
        }

        public void SetCacheValue(string key, CalculateModel model)
        {
            if (_memoryCache.TryGetValue(key, out IEnumerable<string> collectionValue))
            {
                var queue = new FixedSizedQueue<string>(TypesConstants.QueueSize, collectionValue);
                queue.Enqueue(SetMemoryValue(model));
                _memoryCache.Set(key, queue);
            }
            else if (_memoryCache.TryGetValue(key, out string value))
            {
                var queue = new FixedSizedQueue<string>(TypesConstants.QueueSize, new List<string>() { value });
                queue.Enqueue(SetMemoryValue(model));
                _memoryCache.Set(key, queue);
            }
            else
            {
                _memoryCache.Set(key, SetMemoryValue(model));
            }
        }

        private string SetMemoryValue(CalculateModel model)
        {
            return string.Concat(model.FirstNumber, model.Operation.GetDescription(), model.SecondNumber, "=", model.Result);
        }
    }
}
