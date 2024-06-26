using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ItemConsoleApp
{
    public class SalesService
    {
        private readonly HttpClientService _httpClientService;

        public SalesService()
        {
            _httpClientService = new HttpClientService();
        }

        public async Task<List<Sale>> GetSalesAsync()
        {
            var response = await _httpClientService.GetAsync("sales");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Sale>>(responseBody);
        }

        public async Task<bool> AddSaleAsync(Sale sale)
        {
            var response = await _httpClientService.PostAsync("sales", sale);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateSaleAsync(string itemCode, Sale sale)
        {
            var response = await _httpClientService.PutAsync($"sales/{itemCode}", sale);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSaleAsync(string itemCode)
        {
            var response = await _httpClientService.DeleteAsync($"sales/{itemCode}");
            return response.IsSuccessStatusCode;
        }
    }
}
