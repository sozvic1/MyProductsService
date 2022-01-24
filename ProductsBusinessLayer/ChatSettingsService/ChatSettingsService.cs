using Microsoft.Extensions.Caching.Distributed;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.ChatSettingsService
{
    public class ChatSettingsService : ISettingsService<ChatUserSettings>
    {
        private readonly IDistributedCache _distributedCache;
        public ChatSettingsService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<ChatUserSettings> GetValueAsync(string key)
        {
            var settingString = await _distributedCache.GetStringAsync(key);

            return JsonSerializer.Deserialize<ChatUserSettings>(settingString);
        }

        public async Task SetValueAsync(string key, ChatUserSettings item)
        {
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(item));
        }
    }
}

