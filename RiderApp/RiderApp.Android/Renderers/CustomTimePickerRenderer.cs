using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using RiderApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TimePicker), typeof(CustomTimePickerRenderer))]
namespace RiderApp.Droid.Renderers
{
    class CustomTimePickerRenderer : TimePickerRenderer
    {
        public CustomTimePickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
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