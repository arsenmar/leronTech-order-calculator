using System.Collections.Generic;

namespace LeronTech.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (key == null)
                return default;

            return dictionary.TryGetValue(key, out var result) ? result : defaultValue;
        }
    }
}
