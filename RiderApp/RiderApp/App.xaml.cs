using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    public partial class App : Application
    {
        public static NavigationPage mainNavigationPage;
        public static MainPage mainPage;
        public App()
        {
            InitializeComponent();

            MainPage = new MenuPage();
            FlyoutPage menu = (FlyoutPage)MainPage;
            mainPage = new MainPage();
            menu.Detail = new NavigationPage(mainPage);
            mainNavigationPage = (NavigationPage)menu.Detail;
            mainNavigationPage.BarBackgroundColor = Color.Black;
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
