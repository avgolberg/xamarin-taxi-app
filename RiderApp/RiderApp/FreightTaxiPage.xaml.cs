using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FreightTaxiPage : ContentPage
    {
        public FreightTaxiPage()
        {
            InitializeComponent();
        }
        private async void InfoTapped(object sender, EventArgs e)
        {
            await Navigation.ShowPopupAsync(new FreightTaxiPopup());
        }
        private async void FreightTariffsTapped(object sender, EventArgs e)
        {
            await Navigation.ShowPopupAsync(new FreightTariffsPopup());
        }
        
        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }
    }
}