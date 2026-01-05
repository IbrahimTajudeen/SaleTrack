using SaleTrack.Services;
using SaleTrack.State;
using SaleTrack.Views;

namespace SaleTrack
{
    public partial class App : Application
    {
        private readonly AppState _appState;
        private readonly ApiService _api;

        public App(AppState appState, ApiService api)
        {
            InitializeComponent();
            //Routing.RegisterRoute("addsale", typeof(AddSalePage));
            _appState = appState;
            _api = api;

            MainPage = new AppShell();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            var token = await SecureStorage.GetAsync("access_token");

            if (!string.IsNullOrEmpty(token))
            {
                _appState.AccessToken = token;
                _api.SetToken(token);

                await Shell.Current.GoToAsync("//dashboard");
            }
            else
            {
                //await Shell.Current.GoToAsync("//dashboard");
                await Shell.Current.GoToAsync("//login");
            }
        }
    }

}
