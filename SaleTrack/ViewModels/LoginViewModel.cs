using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaleTrack.Models;
using SaleTrack.Services;
using SaleTrack.State;

namespace SaleTrack.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthService _auth;
        private readonly ApiService _api;
        private readonly AppState _state;
        private readonly IAlertService _alertService;

        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AuthService auth, ApiService api, AppState state, IAlertService alertService)
        {
            _auth = auth;
            _api = api;
            _state = state;
            _alertService = alertService;
            LoginCommand = new Command(async () => await Login());
        }

        async Task Login()
        {
            IsBusy = true;
            var res = await _api.PostAsync<ApiResponse<AuthResponse>>("auth/signin", new { email = Email, password = Password });
            
            if (res.Success)
            {
                _api.SetToken(res.Data.Session.Token);

                // Setting App State
                _state.AccessToken = res.Data.Session.Token;
                _state.RefreshToken = res.Data.Session.RefreshToken;
                _state.Email = res.Data.Email;
                _state.Role = res.Data.Role;
                _state.Username = res.Data.Username;
                _state.FirstName = res.Data.FirstName;
                _state.LastName = res.Data.LastName;
                _state.LastSignInTime = DateTime.Now;

                await _alertService.ShowSuccess($"Welcome!\n{_state.Username}");

                //await Application.Current.MainPage.DisplayAlert("Logged In", res.Data.Username, "Ok");

                await Shell.Current.GoToAsync("//dashboard");
            }

            IsBusy = false;
        }
    }
}
