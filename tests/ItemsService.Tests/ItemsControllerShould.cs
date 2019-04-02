using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ItemsService.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace ItemsService.Tests
{
    public class ItemsControllerShould : IDisposable
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public ItemsControllerShould()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseKestrel()
                .UseStartup<Startup>());

            var client = server.CreateClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            _client = client;

            _server = server;
        }

        [Fact]
        public async Task AdOneToAll()
        {
            var item = new ItemModel()
            {
                Text = "Test"
            };

            var oldItems = await GetAll();
            await Add(item);
            var newItems = await GetAll();
            Assert.Equal(oldItems.Count + 1, newItems.Count);
            Assert.Contains(newItems, model => model.Text == item.Text);
        }

        private async Task<List<ItemModel>> GetAll()
        {
            var content = new StringContent("");
            var response = await _client.PostAsync("/items/getall", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ItemModel>>(json);
        }

        private async Task Add(ItemModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json);
            content.Headers.Clear();
            content.Headers.Add("Content-Type", new[] {"application/json"});
            var response = await _client.PostAsync("/items/add", content);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }
    }
}