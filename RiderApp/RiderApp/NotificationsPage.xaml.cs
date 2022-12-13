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
    public partial class NotificationsPage : ContentPage
    {
        public ListView Notification { get { return notifications; } }
        public NotificationsPage()
        {
            InitializeComponent();
        }
        private async void CloseTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}