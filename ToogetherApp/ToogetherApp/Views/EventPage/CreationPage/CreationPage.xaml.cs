using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BusinessLogicLayer.ViewModels.Pages.EventPage.Creation;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationPage : ContentPage
    {
        public CreationPage()
        {
            BindingContext = new CreationPageViewModel();
            InitializeComponent();
        }
        public async void OpenEventFeaturesPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new FeatureContentPage(((ImageButton)sender).ClassId), true);
        }
    }
}