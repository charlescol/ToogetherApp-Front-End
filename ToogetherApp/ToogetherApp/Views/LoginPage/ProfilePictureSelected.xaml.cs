using BusinessLogicLayer.ViewModels.Pages.Profile;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePictureSelected : ContentPage
    {
        public ProfilePictureSelected(ProfileViewModel context, ImageSource source = null)
        {
            InitializeComponent();
            selected_image.Source = source;
            BindingContext = context;
            validation_button.ClickedCommand = new Command(OnValidationButtonClicked);
            back_button.ClickedCommand = new Command(OnBackButtonClicked);
        }
        public void OnBackButtonClicked()
        {
            Navigation.PopModalAsync();
        }
        public void OnValidationButtonClicked()
        {
            ((ProfileViewModel)BindingContext).ProfileSource = selected_image.Source;
            Navigation.PopModalAsync();
        }
    }
}