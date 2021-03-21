using Calculator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Services.Interfaces
{
    public interface ICalculateCacheService
    {
        void SetCacheValue(string key, CalculateModel model);

        IEnumerable<string> GetCacheValue(string key);
    }
}
