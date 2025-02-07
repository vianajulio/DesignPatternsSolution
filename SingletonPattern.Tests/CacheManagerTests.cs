namespace SingletonPattern.Tests;

public class CacheManagerTests : IDisposable
{
    public CacheManagerTests()
    {
        CacheManager.Instance.Clear();
    }

    public void Dispose()
    {
        CacheManager.Instance.Clear();
    }

    [Fact]
    public void GetValue_WithKey_ReturnsCorrectValue()
    {
        var user1 = new { Name = "Julio", Age = 21 };
        var user2 = new { Name = "Bruna", Age = 20 };

        CacheManager.Instance.Add("user_1", user1);
        CacheManager.Instance.Add("user_2", user2);

        var cachedUser1 = CacheManager.Instance.Get("user_1");
        var cachedUser2 = CacheManager.Instance.Get("user_2");

        Assert.NotNull(cachedUser1);
        Assert.NotNull(cachedUser2);

        Assert.Equal(user1, cachedUser1);
        Assert.Equal(user2, cachedUser2);
    }

    [Fact]
    public void Get_WhenKeyDoesNotExist_ReturnsNull()
    {
        var result = CacheManager.Instance.Get("non_existent_key");
        Assert.Null(result);
    }

    [Fact]
    public void Remove_WhenKeyExists_RemovesValueFromCache()
    {
        CacheManager.Instance.Add("user_1", new { Name = "Julio", Age = 21 });
        CacheManager.Instance.Remove("user_1");

        var result = CacheManager.Instance.Get("user_1");
        Assert.Null(result);
    }

    [Fact]
    public void Clear_RemovesAllValuesFromCache()
    {
        CacheManager.Instance.Add("user_1", new { Name = "Julio", Age = 21 });
        CacheManager.Instance.Add("user_2", new { Name = "Bruna", Age = 20 });

        CacheManager.Instance.Clear();

        Assert.Null(CacheManager.Instance.Get("user_1"));
        Assert.Null(CacheManager.Instance.Get("user_2"));
    }
}
