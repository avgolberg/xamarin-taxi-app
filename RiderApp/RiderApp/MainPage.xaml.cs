using RiderApp.Helpers;
using RiderApp.Models;
using RiderApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace RiderApp
{
    public partial class MainPage : ContentPage
    {
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();
        ObservableCollection<Car> vehiclesCollection = new ObservableCollection<Car>();
        public MainPage()
        {
            InitializeComponent();
            SetSettings();
        }
        void SetSettings()
        {
            SetCarTypes();

            GoogleMapsApiService.Initialize(Credentials.Credentials.API_KEY);

            AddMapStyle();

            Position position = new Position(46.48372400877479, 30.730843193582036);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(15));
            map.MoveToRegion(mapSpan);
        }

        public class Car
        {
            public string Title { get; set; }
            public ImageSource ImageSource { get; set; }

            public string ImageSourceStr { get; set; }
        }

        void SetCarTypes()
        {
             vehiclesCollection = new ObservableCollection<Car>() { 
                new Car { Title = "Стандарт" + Environment.NewLine + "від 60₴", ImageSource = ImageSource.FromResource("RiderApp.Images.standard-car.png"), ImageSourceStr="RiderApp.Images.standard-car.png"}, 
                new Car { Title = "Бізнес" + Environment.NewLine + "від 81₴", ImageSource = ImageSource.FromResource("RiderApp.Images.business-car2.png"), ImageSourceStr="RiderApp.Images.business-car2.png" }, 
                new Car { Title = "Вантажний" + Environment.NewLine + "від 400₴", ImageSource = ImageSource.FromResource("RiderApp.Images.truck2.png"), ImageSourceStr="RiderApp.Images.truck2.png" }, 
                new Car { Title = "Мінівен" + Environment.NewLine + "від 120₴", ImageSource = ImageSource.FromResource("RiderApp.Images.minivan2.png"), ImageSourceStr="RiderApp.Images.minivan2.png" }, 
                new Car { Title = "Посилка" + Environment.NewLine + "від 60₴", ImageSource = ImageSource.FromResource("RiderApp.Images.parcel2.png"), ImageSourceStr="RiderApp.Images.parcel2.png" } ,
                new Car { Title = "Драйвер" + Environment.NewLine + "їде за кермом" + Environment.NewLine + "вашого авто", ImageSource = ImageSource.FromResource("RiderApp.Images.driver2.png"), ImageSourceStr="RiderApp.Images.driver2.png" },
            };
             vehicles.ItemsSource = vehiclesCollection;
        }

        void AddMapStyle()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"RiderApp.MapStyle.json");

            string styleFile;
            if (stream != null)
            {
                using (var reader = new System.IO.StreamReader(stream))
                {
                    styleFile = reader.ReadToEnd();
                    map.MapStyle = MapStyle.FromJson(styleFile);
                }
            }

            map.UiSettings.ZoomControlsEnabled = false;
        }


        public async void LoadRoute(Position start, Position end)
        {
            var positionIndex = 1;
            var googleDirection = await googleMapsApi.GetDirections(start.Latitude.ToString(), start.Longitude.ToString(), end.Latitude.ToString(), end.Longitude.ToString());
            if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
            {
                var positions = (Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points)));
                Calculate(positions);

                //Location tracking simulation
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (positions.Count > positionIndex)
                    {
                        Update(positions[positionIndex]);
                        positionIndex++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            else
            {
                await DisplayAlert(":(", "No route found", "Ok");
            }
        }

        async void Update(Position position)
        {
            if (map.Pins.Count == 1)
                return;

            var cPin = map.Pins.FirstOrDefault();

            if (cPin != null)
            {
                cPin.Position = new Position(position.Latitude, position.Longitude);
                //cPin.Icon = BitmapDescriptorFactory.FromView(new Image() { Source = ImageSource.FromResource($"RiderApp.Images.business-car.png"), WidthRequest = 25, HeightRequest = 25 });

                await map.MoveCamera(CameraUpdateFactory.NewPosition(new Position(position.Latitude, position.Longitude)));
                var previousPosition = map.Polylines.FirstOrDefault().Positions.FirstOrDefault();
                map.Polylines?.FirstOrDefault()?.Positions?.Remove(previousPosition);
            }
            else
            {
                //END TRIP
                map.Polylines?.FirstOrDefault()?.Positions?.Clear();
            }


        }

        void Calculate(List<Position> list)
        {
            map.Polylines.Clear();
            var polyline = new Xamarin.Forms.GoogleMaps.Polyline();
            foreach (var p in list)
            {
                polyline.Positions.Add(p);

            }
            map.Polylines.Add(polyline);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(polyline.Positions[0].Latitude, polyline.Positions[0].Longitude), Distance.FromMiles(0.50f)));

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(polyline.Positions.First().Latitude, polyline.Positions.First().Longitude),
                Label = "First",
                Address = "First",
                Tag = string.Empty
                // Icon = BitmapDescriptorFactory.FromView(new Image() { Source = "ic_taxi.png", WidthRequest = 25, HeightRequest = 25 }
               //)
            };
            map.Pins.Add(pin);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(polyline.Positions.Last().Latitude, polyline.Positions.Last().Longitude),
                Label = "Last",
                Address = "Last",
                Tag = string.Empty
            };
            map.Pins.Add(pin1);
        }

        private async void address_Focused(object sender, FocusEventArgs e)
        {
            FindAddressPage findAddressPage = new FindAddressPage();
            findAddressPage.DidFinishPoping += (start, end) =>
            {
                LoadRoute(start, end);

                //Change page style
                //makeOrderPage.IsVisible = false;
                //showRoutePage.IsVisible = true;
            };
            await Navigation.PushAsync(findAddressPage);
        }

        private void vehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = (sender as CollectionView).SelectedItem as Car;
            int index = vehiclesCollection.IndexOf(car);

            if (index != -1)
            {
                car.ImageSourceStr = car.ImageSourceStr.Remove(car.ImageSourceStr.IndexOf("2"), 1);
                car.ImageSource = ImageSource.FromResource(car.ImageSourceStr);
                vehiclesCollection[index] = car;

                for (int i = 0; i < vehiclesCollection.Count; i++)
                {
                    if (i != index && !vehiclesCollection[i].ImageSourceStr.Contains("2"))
                    {
                        Car notSelected = vehiclesCollection[i];
                        notSelected.ImageSourceStr = notSelected.ImageSourceStr.Insert(notSelected.ImageSourceStr.LastIndexOf("."), "2");
                        notSelected.ImageSource = ImageSource.FromResource(notSelected.ImageSourceStr);
                        vehiclesCollection[i] = notSelected;
                    }
                }

                vehicles.ItemsSource = vehiclesCollection;
            }
        }
    }
}
