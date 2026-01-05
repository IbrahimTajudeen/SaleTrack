using Microsoft.Extensions.Logging;
using SaleTrack.Services;
using SaleTrack.Models;
using SaleTrack.ViewModels;
using SaleTrack.Views;
using SaleTrack.State;

namespace SaleTrack
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

        #if DEBUG
    		builder.Logging.AddDebug();
        #endif

            // 🔹 Core services
            builder.Services.AddSingleton<AppState>();
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddSingleton<AuthService>();
            //builder.Services.AddSingleton<SalesService>();
            //builder.Services.AddSingleton<ReportService>();
            builder.Services.AddSingleton<AppState>();
            builder.Services.AddSingleton<IAlertService, AlertService>();

            // 🔹 ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<SalesViewModel>();
            builder.Services.AddTransient<AddSaleViewModel>();
            builder.Services.AddTransient<ReportsViewModel>();
            
            // 🔹 Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<DashboardPage>();
            builder.Services.AddTransient<SalesPage>();
            builder.Services.AddTransient<AddSalePage>();
            builder.Services.AddTransient<ReportsPage>();


            return builder.Build();
        }
    }
}
