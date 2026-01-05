using SaleTrack.Views;

namespace SaleTrack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("addsale", typeof(AddSalePage));
        }
    }
}
