using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToogetherApp.Droid.Renderer;
using ToogetherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MapPage), typeof(CustomMapPageRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer
{
    public class CustomMapPageRenderer_Droid : PageRenderer
    {
        public CustomMapPageRenderer_Droid(Context context) : base(context)
        {}
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            base.ba
        }
    }
}