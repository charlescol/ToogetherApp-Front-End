using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToogetherApp.Views.Resources.Event;
using System.Collections.ObjectModel;
namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public ObservableCollection<View> Views { get; set; } = new ObservableCollection<View>();
        public EventPage()
        {
            
            InitializeComponent();
            BindingContext = this;


        }
        public async void OpenCreationPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new CreationPage(), true);
        }
        public async void OpenCreatedPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new BasicShowingEventPage("Créés"), true);
        }
        public async void OpenLikedPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new LikedPage(), true);
        }
        public async void OpenParticipatedPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new BasicShowingEventPage("A Venir"), true);
        }
        public async void OpenHistoricalPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new BasicShowingEventPage("Historique"), true);
        }

    }
}