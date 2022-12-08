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
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
        }

        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = false;
        }

        private async void DeleteTappedAsync(object sender, EventArgs e)
        {
           var response = await  DisplayAlert("Увага", "Ви впевнені, що хочете видалити свій акаунт?", "Так", "Ні");
            if (response)
            {
                // Delete a rider`s account from DB
            }
        }
    }
}