using RiderApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.OS;
using Android.Content.Res;
using Android.Graphics;
using Android.MyRenderers;

[assembly: ExportRenderer(typeof(Entry), typeof(MyRenderers))]
namespace Android.MyRenderers
{
    public class MyRenderers : EntryRenderer
    {

        public MyRenderers(Context context) : base(Android.App.Application.Context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Ivory);
            else
                Control.Background.SetColorFilter(Android.Graphics.Color.Ivory, PorterDuff.Mode.SrcAtop);
        }
    }
}