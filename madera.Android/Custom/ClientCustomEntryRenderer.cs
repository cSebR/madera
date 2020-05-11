using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using madera.Custom;
using madera.Droid.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryClient), typeof(ClientCustomEntryRenderer))]
namespace madera.Droid.Custom
{
    public class ClientCustomEntryRenderer: EntryRenderer
    {
        public ClientCustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.White);
                gd.SetCornerRadius(30);
                Control.Background = gd;
                Control.SetPadding(20,5,20,5);
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Violet));
            }
        }
    }
}