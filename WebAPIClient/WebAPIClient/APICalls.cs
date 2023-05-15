using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    public class APICalls
    {
        private readonly HttpClient _client;
        private readonly string _url;
        public APICalls(string url)
        {
            _client = new HttpClient();
            _url = url;
        }
        public async Task<string> Get()
        {
            var response = await _client.GetAsync(_url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> GetById(int id)
        {
            var response = await _client.GetAsync($"{_url}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }/*
        public async Task<string> Post(string value)
        {
           var content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }*/

        public async Task<string> Post(byte[] data,string Endpoint)
        {
            var content = new ByteArrayContent(data);
            content.Headers.TryAddWithoutValidation("Content-Type", "application/x-msgpack");
            var response = await _client.PostAsync(_url+Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Server returned {response.StatusCode}: {errorMessage}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
