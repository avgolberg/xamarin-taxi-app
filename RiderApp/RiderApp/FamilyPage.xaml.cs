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
    public partial class FamilyPage : ContentPage
    {
        public FamilyPage()
        {
            InitializeComponent();
        }
        private async void AddTapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(phone.Text))
            {
                //Request to server
                await DisplayAlert("Успішна операція", "Телефон додано!", "Ок");
                FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
                menu.Detail = App.mainNavigationPage;
            }
            else await DisplayAlert("Помилка", "Введіть номер телефону", "Ок");
        }

        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }
    }
}