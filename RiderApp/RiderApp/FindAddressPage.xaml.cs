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
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();
        double StartLatitude { get; set; }
        double StartLongitude { get; set; }
        double EndLatitude { get; set; }
        double EndLongitude { get; set; }
        bool IsStartFocused { get; set; }

        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; } = new ObservableCollection<GooglePlaceAutoCompletePrediction>();

        public bool ShowRecentPlaces { get; set; }

        public delegate void HandlePopDelegate(Position start, Position end);
        public event HandlePopDelegate DidFinishPoping;

        public FindAddressPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            startLocation.Focus();
            IsStartFocused = true;
            addressesListView.ItemsSource = RecentPlaces;
        }
        private async void Location_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((sender as Entry).IsFocused)
                await GetPlacesByName(e.NewTextValue);
        }

        private async void addressesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await GetPlacesDetail(e.SelectedItem as GooglePlaceAutoCompletePrediction);
        }
        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
            }
            
            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);
            if (!ShowRecentPlaces) 
                addressesListView.ItemsSource = Places;
            else
                addressesListView.ItemsSource = RecentPlaces;
        }

        public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
        {
            addressesListView.ItemsSource = RecentPlaces;

            var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if (place != null)
            {
                if (IsStartFocused)
                {
                    startLocation.Text = placeA.StructuredFormatting.MainText;
                    StartLatitude = place.Latitude;
                    StartLongitude = place.Longitude;
                    endLocation.Focus();
                    IsStartFocused = false;
                }
                else 
                {
                    endLocation.Text = placeA.StructuredFormatting.MainText;
                    EndLatitude = place.Latitude;
                    EndLongitude = place.Longitude;
                    startLocation.Focus();
                    IsStartFocused = true;
                }

                RecentPlaces.Add(placeA);

                if(StartLatitude != 0 && EndLatitude != 0)
                {
                    if (StartLatitude == EndLatitude && StartLongitude == EndLongitude)
                    {
                        await DisplayAlert("Error", "Origin route should be different from destination route", "Ok");
                    }
                    else
                    {
                        await Navigation.PopAsync();
                        DidFinishPoping(new Position(StartLatitude, StartLongitude), new Position(EndLatitude, EndLongitude));
                    }
                }
              
            }
        }
    }
}