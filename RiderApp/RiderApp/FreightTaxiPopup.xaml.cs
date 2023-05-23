﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FreightTaxiPopup : Popup
    {
        public FreightTaxiPopup()
        {
            InitializeComponent();
        }
         
        private void CloseTapped(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}