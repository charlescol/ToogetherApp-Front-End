using BusinessLogicLayer;
using BusinessLogicLayer.ViewModels.Pages.Profile;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProfilePictureView : ContentView
    {
        public AddProfilePictureView(ProfileViewModel context)
        {
            InitializeComponent();
            BindingContext = context;
            gallery_button.ClickedCommand = new Command(OnGalleryClicked);
            camera_button.ClickedCommand = new Command(OnCameraButtonClicked);
        }
        public async void OnGalleryClicked()
        {
            await Navigation.PushModalAsync(new ProfilePictureSelected((ProfileViewModel)BindingContext, await Media.OpenGallery()));
        }
        private async void OnCameraButtonClicked()
        {
            await Navigation.PushModalAsync(new ProfilePictureSelected((ProfileViewModel)BindingContext, await Media.TakePicture()));
        }
        void OnDragStarting(object sender, DragStartingEventArgs e)
        {
            Shape shape = (sender as Element).Parent as Shape;
        }
    }
}