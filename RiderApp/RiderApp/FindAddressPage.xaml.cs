using RiderApp.Models;
using RiderApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        string StartLatitude { get; set; }
        string StartLongitude { get; set; }
        string EndLatitude { get; set; }
        string EndLongitude { get; set; }

        bool IsStartFocused { get; set; }

        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
        public GooglePlace StartPlaceSelected { get; set; }
        public GooglePlace EndPlaceSelected { get; set; }
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
            IsStartFocused = true;
            startLocation.Focus();
        }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
                addressesListView.ItemsSource = Places;
            }
            
            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);            
        }

        public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
        {
            var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if (place != null)
            {
                if (IsStartFocused)
                {
                    startLocation.Text = placeA.StructuredFormatting.MainText;
                    StartPlaceSelected = place;
                    StartLatitude = $"{place.Latitude}";
                    StartLongitude = $"{place.Longitude}";

                    IsStartFocused = false;
                    endLocation.Focus();
                }
                else
                {
                    endLocation.Text = placeA.StructuredFormatting.MainText;
                    EndPlaceSelected = place;
                    EndLatitude = $"{place.Latitude}";
                    EndLongitude = $"{place.Longitude}";

                    RecentPlaces.Add(placeA);

                    if (StartLatitude == EndLatitude && StartLongitude == EndLongitude)
                    {
                        await DisplayAlert("Error", "Origin route should be different from destination route", "Ok");
                    }
                    else
                    {
                        await Navigation.PopAsync(); 
                        DidFinishPoping(new Position(double.Parse(StartLatitude), double.Parse(StartLongitude)), new Position (double.Parse(EndLatitude), double.Parse(EndLongitude)));
                        CleanFields();
                    }
                }
            }
        }

        void CleanFields()
        {
            startLocation.Text = endLocation.Text = string.Empty;
            ShowRecentPlaces = true;
        }

        private async void Location_TextChanged(object sender, TextChangedEventArgs e)
        {
            await GetPlacesByName(e.NewTextValue);
        }

        private async void addressesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await GetPlacesDetail(e.SelectedItem as GooglePlaceAutoCompletePrediction);
        }
    }
}