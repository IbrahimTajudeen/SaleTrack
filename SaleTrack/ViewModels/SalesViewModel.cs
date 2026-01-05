using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaleTrack.Services;
using SaleTrack.Models;


namespace SaleTrack.ViewModels
{
    public class SalesViewModel : BaseViewModel
    {
        private readonly ApiService _api;
        public ObservableCollection<Sale> Sales { get; } = new();

        public ICommand LoadCommand { get; }
        public ICommand AddSaleCommand { get; }

        public SalesViewModel(ApiService api)
        {
            _api = api;
            LoadCommand = new Command(async () => await Load());
            AddSaleCommand = new Command(async () => await AddSales());
        }

        async Task AddSales() => await Shell.Current.GoToAsync("addsale"); 

        async Task Load()
        {
            IsBusy = true;
            var list = await _api.GetAsync<List<Sale>>("my-sales");
            Sales.Clear();
            foreach (var s in list) Sales.Add(s);
            IsBusy = false;
        }
    }

}
