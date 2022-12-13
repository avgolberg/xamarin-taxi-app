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
    public partial class LanguagesPage : ContentPage
    {
        public ListView Language { get { return languages; } }
        public LanguagesPage()
        {
            InitializeComponent();
        }

        private async void CloseTapped(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }
    }
}