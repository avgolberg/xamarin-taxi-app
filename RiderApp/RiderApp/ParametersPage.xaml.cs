using RiderApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametersPage : ContentPage
    {
        public ParametersPage()
        {
            InitializeComponent();
        }

        private async void languages_Tapped(object sender, EventArgs e)
        {
            var languagesPage = new LanguagesPage();
            languagesPage.Language.ItemSelected += (source, args) =>
            {
                if (args.SelectedItem != null)
                {
                    language.Text = (args.SelectedItem as CustomSwitchCell).Label;
                    languagesPage.Language.SelectedItem = null;
                    Navigation.PopAsync();
                }
            };
            await Navigation.PushAsync(languagesPage);
        }
        private async void notifications_Tapped(object sender, EventArgs e)
        {
            var notificationsPage = new NotificationsPage();
            notificationsPage.Notification.ItemSelected += (source, args) =>
            {
                if (args.SelectedItem != null)
                {
                    notifications.Text = (args.SelectedItem as CustomSwitchCell).Label;
                    notificationsPage.Notification.SelectedItem = null;
                    Navigation.PopAsync();
                }
            };
            await Navigation.PushAsync(notificationsPage);
        }

        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }
    }
}