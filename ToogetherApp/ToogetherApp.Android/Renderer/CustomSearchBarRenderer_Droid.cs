using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using ToogetherApp.Droid.Renderer;
using ToogetherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer
{
    public class CustomSearchBarRenderer_Droid : SearchBarRenderer
    {
        public CustomSearchBarRenderer_Droid(Context context) : base(context)
        {}

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove bottom line
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);

                // Set search Icon
                Control.Iconified = true;
                Control.SetIconifiedByDefault(false);
                int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                ImageView icon = Control.FindViewById(searchIconId) as ImageView;
                icon.SetImageResource(Resource.Drawable.search_icon); // Replace
                icon.SetColorFilter(Android.Graphics.Color.Orange); // Set color
            }
        }
    }
}