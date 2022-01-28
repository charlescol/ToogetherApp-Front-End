using System;
using System.Threading.Tasks;
using ToogetherApp.Views.Resources;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    /* Page called up when clicking on the Map tab */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        PanContainer panContainer = null;
        public MapPage()
        {
            BindingContext = new BusinessLogicLayer.ViewModels.Pages.MapPageViewModel();
            InitializeComponent();
            var window = new EventFocusWindows();
            panContainer = new PanContainer(CurrentPosType.Max)
            {// need to create EventFocusWindows Custom renderer to add corner radius (only) on the top
                Content = window,
                BackgroundColor = Color.White,
                Padding = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false
            };
            window.HandlerCurrentScrolled += panContainer.Scrolled;
            AbsoluteLayout.SetLayoutBounds(panContainer, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(panContainer, AbsoluteLayoutFlags.All);
            main_layout.Children.Add(panContainer);
        }
        /* When a size is assigned to the page (not always the case in the OnApparing method) we specify
         * the different positions of the PanContainer levels according to the size of the page */
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            panContainer.SetPos(new float[] { 0, (float)(width * 0.7), (float)(height * 0.8) });
            panContainer.Update();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            panContainer.IsVisible = false;
        }
        /* Method to call to init the PanContainer position levels*/
        /* Method to call to open the SearchPage */
        public async void show_searchPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SearchPage(), false);
        }
        /* Method to call to show/not show the PanContainer */
        public void show_pop_up(object sender, EventArgs args)
        {
            panContainer.IsVisible = !panContainer.IsVisible;
        }
        /* Method to call to update asynchronously the map's events */
        public async void UpdateAllDataAsync()
        {
            var eventList = await ((BusinessLogicLayer.ViewModels.Pages.MapPageViewModel)BindingContext).UpdateAllDataAsync();
            CurentMap.SetEntities(DependencyService.Get<BusinessLogicLayer.Adapters.IMapBoxJsonAdapter>().ToJson(eventList));
        }
        public void showSearchBarAsync(object sender, EventArgs args)
        {
            Task.Run(() => UpdateAllDataAsync());
        }

    }
}