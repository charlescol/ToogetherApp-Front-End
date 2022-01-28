using Android.Content;
using Android.Graphics.Drawables;
using ToogetherApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEntryMultilineRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer
{
    class CustomEntryMultilineRenderer_Droid : EditorRenderer
    {
        public CustomEntryMultilineRenderer_Droid(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove bottom line
                Control.SetBackground(null);
            }
        }
    }
}