using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSwitchCell : ViewCell
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(CustomSwitchCell));
        public string Label 
        { 
            get { return (string)GetValue(LabelProperty); } 
            set { SetValue(LabelProperty, value); } 
        }

        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create("IsToggled", typeof(bool), typeof(CustomSwitchCell));
        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(int), typeof(CustomSwitchCell));
        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public CustomSwitchCell()
        {
            InitializeComponent();
            BindingContext = this;
            IsToggled = false;
            FontSize = 18;
        }
        private void SwitchTapped(object sender, EventArgs e)
        {
            IsToggled = !IsToggled;
        }
    }
}