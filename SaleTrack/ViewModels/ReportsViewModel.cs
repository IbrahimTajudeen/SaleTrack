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
    public class ReportsViewModel : BaseViewModel
    {
        private readonly ApiService _api;
        public ObservableCollection<Report> Reports { get; } = new();

        public ICommand LoadCommand { get; }

        public ReportsViewModel(ApiService api)
        {
            _api = api;
            LoadCommand = new Command(async () => await Load());
        }

        async Task Load()
        {
            var list = await _api.GetAsync<List<Report>>("/reports");
            Reports.Clear();
            foreach (var r in list) Reports.Add(r);
        }
    }

}
