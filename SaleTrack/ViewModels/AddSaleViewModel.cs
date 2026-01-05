using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaleTrack.Models;
using SaleTrack.Services;

namespace SaleTrack.ViewModels
{
    public class AddSaleViewModel : BaseViewModel
    {
        private readonly ApiService _api;

        private NewSale _newSale;
        public NewSale NewSale
        {
            get => _newSale;
            set => SetProperty(ref _newSale, value);
        }


        public ObservableCollection<NewSale> BulkSale { get; }

        public ICommand SaveSaleCommand { get; }
        public ICommand AddSaleCommand { get; }
        public ICommand CloseCommand { get; }

        public AddSaleViewModel(ApiService api)
        {
            _api = api;
            BulkSale = new ObservableCollection<NewSale>();
            NewSale = new NewSale();

            SaveSaleCommand = new Command(async () => await Save());
            CloseCommand = new Command(async () => await ClosePage());
            AddSaleCommand = new Command(AddSale);
        }


        async Task ClosePage() => await Shell.Current.GoToAsync("..");

        void ClearSales(bool allBucket = false)
        {
            NewSale.SaleDate = DateTime.Today;
            NewSale.ItemName = string.Empty;
            NewSale.PricePerItem = 0m;
            NewSale.Quantity = 1;
            NewSale.Notes = string.Empty;

            if (allBucket)
                BulkSale.Clear();
        }


        void AddSale()
        {
            BulkSale.Add(new NewSale
            {
                SaleDate = NewSale.SaleDate,
                ItemName = NewSale.ItemName,
                PricePerItem = NewSale.PricePerItem,
                Quantity = NewSale.Quantity,
                Notes = NewSale.Notes
            });

            ClearSales();
        }

        async Task Save()
        {
            IsBusy = true;
            if (BulkSale.Count == 0)
                await _api.PostAsync<ApiResponse<object>>("sales/add-sales", new
                {
                    saleDate = NewSale.SaleDate,
                    itemName = NewSale.ItemName,
                    pricePerItem = NewSale.PricePerItem,
                    quantity = NewSale.Quantity,
                    notes = NewSale.Notes
                });

            else
            {
                if (NewSale.ItemName != "")
                    AddSale();

                await _api.PostAsync<ApiResponse<object>>("/sales/bulk", BulkSale);
            }

            ClearSales(true);
            IsBusy = false;
        }
    }
}
