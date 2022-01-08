using System.Net.Http.Json;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using Blazored.LocalStorage;

namespace ActionCommandGame.Sdk
{
    public class ItemApi: IItemApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;


        public ItemApi(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<ServiceResult<IList<ItemResult>>> FindAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("ActionCommandGame");
            var token = await _localStorageService.GetItemAsync<string>("Token");
            httpClient.AddAuthorization(token);
            var route = "items";

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<IList<ItemResult>>>();

            if (result is null)
            {
                return new ServiceResult<IList<ItemResult>>();
            }

            return result;
        }

        public async Task<ServiceResult<ItemResult>> DeleteAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ActionCommandGame");
            var token = await _localStorageService.GetItemAsync<string>("Token");

            httpClient.AddAuthorization(token);
            var route = $"items/{id}";

            var httpResponse = await httpClient.DeleteAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<ItemResult>>();

            if (result is null)
            {
                return new ServiceResult<ItemResult>();
            }

            return result;
        }
    }
}
