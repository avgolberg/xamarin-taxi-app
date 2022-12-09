using RiderApp.Helpers;
using RiderApp.Models;
using RiderApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindAddressPage : ContentPage
    {
        OrderHelper oh;

        public delegate void HandlePopDelegate(Position start, Position end);
        public event HandlePopDelegate DidFinishPoping;

        public FindAddressPage()
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
                    await Navigation.PopAsync();
                    DidFinishPoping(new Position(oh.StartLatitude, oh.StartLongitude), new Position(oh.EndLatitude, oh.EndLongitude));
                }
            }
        }
    }
}