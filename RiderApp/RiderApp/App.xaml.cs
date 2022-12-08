using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    public partial class App : Application
    {
        public static NavigationPage mainPage;
        public App()
        {
            InitializeComponent();
            MainPage = new MenuPage();
            FlyoutPage menu = (FlyoutPage) MainPage;
            mainPage = menu.Detail as NavigationPage;
            mainPage.BarBackgroundColor = Color.Black;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
