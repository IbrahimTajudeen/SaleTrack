using SaleTrack.ViewModels;

namespace SaleTrack.Views;

public partial class AddSalePage : ContentPage
{
	public AddSalePage(AddSaleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}