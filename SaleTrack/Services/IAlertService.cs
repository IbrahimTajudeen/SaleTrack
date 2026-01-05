using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleTrack.Services
{
    public interface IAlertService
    {
        Task ShowError(string message);
        Task ShowSuccess(string message);
    }

    public class AlertService : IAlertService
    {
        public Task ShowError(string message) =>
            Application.Current.MainPage.DisplayAlert("Error", message, "OK");

        public Task ShowSuccess(string message) =>
            Application.Current.MainPage.DisplayAlert("Success", message, "OK");
    }

}
