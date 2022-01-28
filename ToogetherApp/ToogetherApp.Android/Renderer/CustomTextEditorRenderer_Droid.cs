using Android.Content;
using ToogetherApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomTextEditorRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer
{
    class CustomTextEditorRenderer_Droid : EditorRenderer
    {
        public CustomTextEditorRenderer_Droid(Context context) : base(context)
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