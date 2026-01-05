using SaleTrack.ViewModels;

namespace SaleTrack.Views;

public partial class SalesPage : ContentPage
{
	public SalesPage(SalesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}