﻿using Android.Content;
using RiderApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TableView), typeof(CustomTableViewRenderer))]
namespace RiderApp.Droid.Renderers
{
    class CustomTableViewRenderer : TableViewRenderer
    {
        public CustomTableViewRenderer(Context context) : base(Android.App.Application.Context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            var listView = Control as global::Android.Widget.ListView;
            listView.Divider.SetTint(Color.Transparent.GetHashCode());
            listView.SetHeaderDividersEnabled(false);
            listView.Divider = null;
            listView.DividerHeight = 0;
        }
    }
}