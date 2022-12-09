using RiderApp.Models;
using RiderApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RiderApp.Helpers
{
    class OrderHelper
    {
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public bool IsStartFocused { get; set; }

        public double Price { get; set; }

        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; } = new ObservableCollection<GooglePlaceAutoCompletePrediction>();

        public bool ShowRecentPlaces { get; set; }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
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
                    StartLatitude = place.Latitude;
                    StartLongitude = place.Longitude;
                }
                else
                {
                    EndLatitude = place.Latitude;
                    EndLongitude = place.Longitude;
                }

                RecentPlaces.Add(placeA);
            }
        }

        public void CalculatePrice()
        {
            //Request to server
            Price = 175;
        }
    }
}
