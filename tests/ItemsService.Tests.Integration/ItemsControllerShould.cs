using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ItemsService.UI.MvcRpc;
using ItemsService.UI.MvcRpc.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace ItemsService.Tests.Integration
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
            var item = new ItemCreateModel
            {
                Name = "Test",
                Price = 0
            };

            var oldItems = await GetAll();
            await Add(item);
            var newItems = await GetAll();
            Assert.Equal(oldItems.Count + 1, newItems.Count);
            Assert.Contains(newItems, model => model.Name == item.Name);
        }

        private async Task<List<ItemReadModel>> GetAll()
        {
            var content = new StringContent("");
            var response = await _client.PostAsync("/items/getall", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ItemReadModel>>(json);
        }

        private async Task Add(ItemCreateModel model)
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