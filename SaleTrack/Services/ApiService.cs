using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using SaleTrack.Helpers;
using SaleTrack.Models;
using SaleTrack.State;

namespace SaleTrack.Services
{

    public class ApiException(string Message): Exception { }


    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly AppState _state;
        private readonly AlertService _alertService;

        public ApiService(AppState state)
        {
            _state = state;
            _alertService = new AlertService();
            _http = new HttpClient
            {
                BaseAddress = new Uri(Constants.ApiBaseUrl)
            };
        }

        public void SetToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<T> SendAsync<T>(Func<Task<HttpResponseMessage>> request)
        {
            var response = await request();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshed = await RefreshToken();

                if (!refreshed)
                    throw new UnauthorizedAccessException();
                response = await request();
            }

            if (!response.IsSuccessStatusCode)
                throw new ApiException(await response.Content.ReadAsStringAsync());

            return JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync());
        }

        private async Task<bool> RefreshToken()
        {
            var refreshToken = await SecureStorage.GetAsync("refresh_token");
            if (string.IsNullOrEmpty(refreshToken)) return false;

            var res = await _http.PostAsJsonAsync("auth/refresh", new
            {
                refresh_token = refreshToken
            });

            if (!res.IsSuccessStatusCode) return false;

            var result = JsonConvert.DeserializeObject<AuthResponse>(
                await res.Content.ReadAsStringAsync());

            _state.AccessToken = result.Session.Token;
            await SecureStorage.SetAsync("access_token", result.Session.Token);

            SetToken(result.Session.Token);
            return true;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var res = await _http.GetAsync(url);
            res.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(
                await res.Content.ReadAsStringAsync());
        }

        public async Task<T> PostAsync<T>(string url, object body) where T: new()
        {
            try
            {
                var json = JsonConvert.SerializeObject(body);
                await Application.Current.MainPage.DisplayAlert("Hi! Object", json, "ok");
                var res = await _http.PostAsync(
                    url,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

                var data = await res.Content.ReadAsStringAsync();

                await Application.Current.MainPage.DisplayAlert("Hi! Error", data, "ok");

                if (!res.IsSuccessStatusCode)
                {
                    ApiError error = JsonConvert.DeserializeObject<ApiError>(data);
                    await _alertService.ShowError($"{error.Message.Error}:\n{error.Message.Message}");
                    return new T();
                }

                res.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<T>(data);
            } catch (Exception ex)
            {
                await _alertService.ShowError($"Error occured:\n{ex.Message}");
                return new T();
            }
        }
    }
}
