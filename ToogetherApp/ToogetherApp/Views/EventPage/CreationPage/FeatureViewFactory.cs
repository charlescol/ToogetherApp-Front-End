using Xamarin.Forms;

namespace ToogetherApp.Views
{
    public class FeatureViewFactory
    {
        public static FeatureView Create(FeatureContent view)
        {
            var featureView = new FeatureView();
            if (view.IconsSource.Count != view.IconsText.Count) return null;
            featureView.ClearGrid();
            for (int i = 0; i < view.IconsSource.Count; i++)
            {
                var container = new Frame()
                {
                    Padding = 10,
                    HeightRequest = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.White,
                    CornerRadius = 35,
                    BorderColor = Color.Black,
                    Content = new ImageButton()
                    {
                        BackgroundColor = Color.Transparent,
                        Source = view.IconsSource[i],
                        ClassId = view.IconsClassID[i]
                    }
                };
                ((ImageButton)container.Content).Clicked += featureView.OnIconClicked;
                var text = new Label()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.White,
                    Text = view.IconsText[i]
                };
                featureView.AddToGrid(container, i, 0);
                featureView.AddToGrid(text, i, 1);
            }
            view.Content.HorizontalOptions = LayoutOptions.FillAndExpand;
            view.Content.VerticalOptions = LayoutOptions.FillAndExpand;
            featureView.AddToContent(view.Content);
            featureView.Title = view.Title;
            featureView.ClassId = view.Name;
            return featureView;
        }
    }
}
