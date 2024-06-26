using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ItemConsoleApp
{
    public class HttpClientService
    {
        private readonly HttpClient _client;

        public HttpClientService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/api/") // Adjust base address as needed
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _client.GetAsync(endpoint);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return await _client.PostAsync(endpoint, httpContent);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return await _client.PutAsync(endpoint, httpContent);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _client.DeleteAsync(endpoint);
        }
    }
}
