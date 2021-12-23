﻿using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Filters;
using ActionCommandGame.Services.Model.Results;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace ActionCommandGame.Sdk
{
    public class PlayerApi : IPlayerApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;


        public PlayerApi(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<ServiceResult<PlayerResult>> GetAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ActionCommandGame");
            var token = await _localStorageService.GetItemAsync<string>("Token");

            httpClient.AddAuthorization(token);
            var route = $"players/{id}";

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<PlayerResult>>();

            if (result is null)
            {
                return new ServiceResult<PlayerResult>();
            }

            return result;
        }

        public async Task<ServiceResult<IList<PlayerResult>>> Find(PlayerFilter filter)
        {
            var httpClient = _httpClientFactory.CreateClient("ActionCommandGame");
            var token = await _localStorageService.GetItemAsync<string>("Token");

            httpClient.AddAuthorization(token);
            var route = "players";

            if (filter.FilterUserPlayers.HasValue && filter.FilterUserPlayers.Value)
            {
                route += $"?FilterUserPlayers={filter.FilterUserPlayers}";
            }

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<IList<PlayerResult>>>();

            if (result is null)
            {
                return new ServiceResult<IList<PlayerResult>>();
            }

            return result;
        }

        public async Task<ServiceResult<PlayerResult>> Create(PlayerResult playerResult)
        {
            var httpClient = _httpClientFactory.CreateClient("ActionCommandGame");
            var token = await _localStorageService.GetItemAsync<string>("Token");

            httpClient.AddAuthorization(token);
            var route = "players";

            var httpResponse = await httpClient.PostAsJsonAsync(route, playerResult);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<PlayerResult>>();

            if (result is null)
            {
                return new ServiceResult<PlayerResult>();
            }

            return result;
        }

        public async Task Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ActionCommandGame");
            var token = await _localStorageService.GetItemAsync<string>("Token");

            httpClient.AddAuthorization(token);
            var route = $"players/{id}";

            var httpResponse = await httpClient.DeleteAsync(route);

            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
