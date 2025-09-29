using System.Runtime.CompilerServices;

namespace ProviderAbstract.Classes
{
    public abstract class ProviderBase
    {
        private Dictionary<string, object> _cache = [];
        internal protected void SetToCache<T>(T obj,[CallerMemberName] string? callerName = null)
        {
            if (obj is null || string.IsNullOrEmpty(callerName))
                throw new ArgumentException();

            _cache[callerName] = obj;
        }
        internal protected T GetFromCache<T>([CallerMemberName] string? callerName = null)
        {
            if(string.IsNullOrEmpty(callerName))
            {
                throw new ArgumentException();
            }
            if(_cache.TryGetValue(callerName,out var value))
            {
                return (T)value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        internal protected bool HasCache([CallerMemberName] string? callerName = null) 
        {
            if (string.IsNullOrEmpty(callerName))
            {
                throw new ArgumentException();
            }
            return _cache.ContainsKey(callerName);
        }
        internal protected async Task<RequestResult<T>> TryUseCache<T>(Task<RequestResult<T>> task, [CallerMemberName] string? callerName = null)
        {
            if (!HasCache())
            {
                var result = await task;
                if (result.IsSuccess)
                {
                    SetToCache(result,callerName);
                }
                return result;
            }
            else
            {
                var data = GetFromCache<RequestResult<T>>(callerName);
                return data;
            }
        }
    }
}
