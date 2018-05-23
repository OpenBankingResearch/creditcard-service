using System.Threading.Tasks;

namespace CreditCardAPI.Cache
{
    public interface ICacheRepository
    {
        Task<object> GetAsync(string key);

        Task SetAsync(string key, object value);
    }
}
