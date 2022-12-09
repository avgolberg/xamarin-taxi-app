using RiderApp.Helpers;
using RiderApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatePricePage : ContentPage
    {
        OrderHelper oh;

        public CalculatePricePage()
        {
            InitializeComponent();
            oh = new OrderHelper();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            startLocation.Focus();
            oh.IsStartFocused = true;
            addressesListView.ItemsSource = oh.RecentPlaces;
        }
        private async void Location_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as Entry).IsFocused)
            {
                await oh.GetPlacesByName(e.NewTextValue);

                if (!oh.ShowRecentPlaces)
                    addressesListView.ItemsSource = oh.Places;
                else
                    addressesListView.ItemsSource = oh.RecentPlaces;
            }          
        }

        private async void addressesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            addressesListView.ItemsSource = oh.RecentPlaces;
            GooglePlaceAutoCompletePrediction placeA = e.SelectedItem as GooglePlaceAutoCompletePrediction;
            await oh.GetPlacesDetail(placeA);
            if (oh.IsStartFocused)
            {
                startLocation.Text = placeA.StructuredFormatting.MainText;
                endLocation.Focus();
                oh.IsStartFocused = false;
            }
            else
            {
                endLocation.Text = placeA.StructuredFormatting.MainText;
                startLocation.Focus();
                oh.IsStartFocused = true;
            }
            if (oh.StartLatitude != 0 && oh.EndLatitude != 0)
            {
                if (oh.StartLatitude == oh.EndLatitude && oh.StartLongitude == oh.EndLongitude)
                {
                    await DisplayAlert("Error", "Origin route should be different from destination route", "Ok");
                }
                else
                {
                    oh.CalculatePrice();

                    addressesListView.IsVisible = false;
                    priceLabel.IsVisible = true;
                    priceLabel.Text = oh.Price.ToString();

                    orderFrame.IsEnabled = true;
                    orderLabel.TextColor = Color.Black;
                }
            }
        }

        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }

        private async void TariffsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TariffsPage());
        }

        private void OrderTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            App.mainPage.LoadRoute(new Position(oh.StartLatitude, oh.StartLongitude), new Position(oh.EndLatitude, oh.EndLongitude));
            menu.Detail = App.mainNavigationPage;
        }
    }
}