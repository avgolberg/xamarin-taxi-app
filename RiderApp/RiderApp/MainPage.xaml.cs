using System;
using System.Collections.Generic;
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
        public MainPage()
        {
            InitializeComponent();
           AddMapStyle();

            Position position = new Position(46.48372400877479, 30.730843193582036);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(15));
                //(position, 0.01, 0.01);
            map.MoveToRegion(mapSpan);
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
          

            
        }
    }
}
