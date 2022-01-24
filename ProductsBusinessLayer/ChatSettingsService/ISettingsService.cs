using System.Threading.Tasks;

namespace ProductsBusinessLayer.ChatSettingsService
{
    public interface ISettingsService<T>
    {
        Task SetValueAsync(string key, T item);
        Task<T> GetValueAsync(string key);
    }
}
