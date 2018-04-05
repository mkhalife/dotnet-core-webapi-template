using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyApp.Infrastructure;
using Newtonsoft.Json;

namespace MyApp.Data
{
    public class DataInitializer
    {
        private MyAppContext _ctx;
        private IConfiguration _config;
        private string _basePath;

        public DataInitializer(MyAppContext ctx, 
            IConfiguration config)
        {
            _ctx = ctx;
            _config = config;

            if (_config["ASPNETCORE_ENVIRONMENT"] == "Development")
            {
                _basePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).FullName).FullName).FullName).FullName;
            }
            else // testing
            {
                _basePath = AppContext.BaseDirectory;
            }
        }

        public async Task SeedAsync()
        {
            // example of loading in items from a file
            // var items = DeserializeJsonFile<Item>("items.json");
            // await _ctx.AddRangeAsync(items);
            // await _ctx.SaveChangesAsync();
            return;
        }

        private async Task<List<T>> DeserialzieJsonFile<T>(string fileName)
        {
            var json = await ReadJsonFileAsync(fileName);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        private async Task<T> DeserializeJsonFile<T>(string fileName)
        {
            var json = await ReadJsonFileAsync(fileName);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private async Task<string> ReadJsonFileAsync(string fileName)
        {
            using (StreamReader reader = new StreamReader(_basePath + "/Data/" + fileName))
            {
                return await reader.ReadToEndAsync();
            }
        }

    }
}