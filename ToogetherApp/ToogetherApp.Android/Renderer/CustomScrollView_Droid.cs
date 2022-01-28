using Android.Content;
using System;
using System.ComponentModel;
using ToogetherApp.Droid.Renderer;
using ToogetherApp.Views.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollViewWithNotBar), typeof(CustomScrollView_Droid))]
namespace ToogetherApp.Droid.Renderer
{
	public class CustomScrollView_Droid : ScrollViewRenderer
	{
		public CustomScrollView_Droid(Context context) : base(context)
		{ }
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
                return;

			if (e.OldElement != null)
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;

			e.NewElement.PropertyChanged += OnElementPropertyChanged;

		}

		protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.HorizontalScrollBarEnabled = false;
			this.VerticalScrollBarEnabled = false;
		}
	}
}