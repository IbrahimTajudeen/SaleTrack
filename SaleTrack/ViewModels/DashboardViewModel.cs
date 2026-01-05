using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleTrack.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SaleTrack.State;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SaleTrack.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly ApiService _api;
        private readonly AppState _state;

        public decimal TodaySales { get; set; } = 12;
        public decimal MonthSales { get; set; } = 105;
        public decimal AllSales { get; set; } = 20405;
        public string Username { get; set; }
        public string Role { get; set; }

        public ICommand SaleCommand { get; }
        public ICommand ReportCommand { get; }
        public ICommand RefreshCommand { get; }
        public ObservableCollection<dynamic> RecentSales { get; set; } = new ObservableCollection<dynamic>
        {
            new {
                ItemName = "Sushi",
                Date = DateTime.Now,
                Quantity = 5,
                Amount = 89.5
            },
            new { ItemName="Airtime", Quantity=1, Amount="₦1,000", Date="Today" },
            new { ItemName="Data Subscription", Quantity=1, Amount="₦2,500", Date="Today" },
            new { ItemName="Electricity", Quantity=1, Amount="₦5,000", Date="Yesterday" },
            new { ItemName="Cable TV", Quantity=1, Amount="₦4,200", Date="Yesterday" },
            new { ItemName="Airtime", Quantity=2, Amount="₦2,000", Date="Yesterday" }
        };


        public DashboardViewModel(ApiService api, AppState state)
        {
            _api = api;
            _state = state;

            SaleCommand = new Command(async () => await Sale());
            ReportCommand = new Command(async () => await Report());
            RefreshCommand = new Command(() => Load());
            Load();
        }

        async Task Sale()
        {
            await Shell.Current.GoToAsync("//sales");
        }

        async Task Report()
        {
            await Shell.Current.GoToAsync("//reports");
        }


        async void Load()
        {
            IsBusy = true;
            var data = new {
                todaySales = 12,
                monthSales = 105
            };
            // await _api.GetAsync<dynamic>("/dashboard/summary");
            
            Username = _state.Username;
            Role = _state.Role;


            TodaySales = data.todaySales;
            MonthSales = data.monthSales;
            OnPropertyChanged(nameof(TodaySales));
            OnPropertyChanged(nameof(MonthSales));
            IsBusy = false;
        }
    }

}
