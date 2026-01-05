using SaleTrack.ViewModels;

namespace SaleTrack.Views;

public partial class ReportsPage : ContentPage
{
	public ReportsPage(ReportsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}