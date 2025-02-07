using System.Collections.Concurrent;

namespace SingletonPattern;

public sealed class CacheManager
{
    private static CacheManager? _instance;
    private static readonly Lock Lock = new();

    private readonly ConcurrentDictionary<string, object> _cache = new();

    private CacheManager() { }

    public static CacheManager Instance
    {
        get
        {
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = new CacheManager();
                }

                return _instance;
            }
        }
    }

    public void Add(string key, object value)
    {
        _cache[key] = value;
    }

    public object? Get(string key)
    {
        _cache.TryGetValue(key, out object? value);
        return value;
    }

    public void Remove(string key)
    {
        _cache.TryRemove(key, out _);
    }

    public void Clear()
    {
        _cache.Clear();
    }
}
