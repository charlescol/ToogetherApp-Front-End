using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        public void OnOpenFlyout(object sender, EventArgs args)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        public async void OnOpenUserParametersPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new SetParametersPage(), true);  
        }
    }
}