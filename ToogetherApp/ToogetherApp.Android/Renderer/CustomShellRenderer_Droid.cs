using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ToogetherApp;
using ToogetherApp.Droid.Renderer;
using Google.Android.Material.BottomNavigation;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(AppShell), typeof(CustomShellRenderer))]
namespace ToogetherApp.Droid.Renderer
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        { }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomShellBottomNavViewAppearanceTracker();
        }
    }
    //Custom tababr appearance
    class CustomShellBottomNavViewAppearanceTracker : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {}

        public void ResetAppearance(BottomNavigationView bottomView)
        {}
        
        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.LayoutParameters.Height = 110;
            bottomView.ItemIconTintList = ColorStateList.ValueOf(Android.Graphics.Color.White);
            bottomView.SetBackgroundResource(Resource.Drawable.backgroundTabImage_color);
        }
    }
}

