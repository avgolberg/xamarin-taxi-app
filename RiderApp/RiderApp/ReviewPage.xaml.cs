using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
        }

        private async void AddPhotoTapped(object sender, EventArgs e)
        {
            string[] actions = new string[] { "Зняти фото", "Медіатека" };
            var action = await DisplayActionSheet("Оберіть джерело", "Відмінити", null, actions);
            FileResult result = null;
            switch (action)
            {
                case "Зняти фото":
                    result = await MediaPicker.CapturePhotoAsync();
                    break;
                case "Медіатека":
                    result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Please pick a photo" });
                    break;
            }
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                Image resultImage = new Image();
                resultImage.Source = ImageSource.FromStream(() => stream);
                photos.Children.Add(resultImage);
            }
        }

        private async void SendTapped(object sender, EventArgs e)
        {
            if (text.Text.Length > 0)
            {
                //request to server
                await DisplayAlert("Дякуємо", "Ваш відкук успішно відправлено!", "Ок");
                FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
                menu.Detail = App.mainNavigationPage;
            }
            else await DisplayAlert("Помилка", "Введіть текст відгука", "Ок");
        }

        private void CloseTapped(object sender, EventArgs e)
        {
            FlyoutPage menu = (FlyoutPage)Application.Current.MainPage;
            menu.IsPresented = true;
            menu.Detail = App.mainNavigationPage;
        }
    }
}