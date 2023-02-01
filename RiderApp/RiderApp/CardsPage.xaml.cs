using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardsPage : ContentPage
    {
        public CardsPage()
        {
            InitializeComponent();
        }
        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }
        private async void AddCardTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Успішна операція", "Картку додано!", "Ок");
        }
        private async void FreezeTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Успішна операція", "Гроші заморожено!", "Ок");
        }
        private async void TopUpTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Успішна операція", "Рахунок поповнено!", "Ок");
        }
        private async void RemoveCardTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Успішна операція", "Картку видалено!", "Ок");
        }
        private async void TermsTapped(object sender, EventArgs e)
        {
            //redirect to TermsPage
            await DisplayAlert("Успішна операція", "Наші положення: ...", "Ок");
        }
        private async void AutoPayTapped(object sender, EventArgs e)
        {
            checkBox.IsChecked = !checkBox.IsChecked;
        }
    }
}