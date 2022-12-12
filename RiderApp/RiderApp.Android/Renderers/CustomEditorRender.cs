using RiderApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.OS;
using Android.Content.Res;
using Android.Graphics;
using Android.MyRenderers;
using Android.Graphics.Drawables;
using Android.Text;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace Android.MyRenderers
{
    public class CustomEditorRenderer : EditorRenderer
    {

        public CustomEditorRenderer(Context context) : base(Android.App.Application.Context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(global::Android.Graphics.Color.Transparent);
            this.Control.SetBackgroundDrawable(gd);
            this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
        }
    }
}