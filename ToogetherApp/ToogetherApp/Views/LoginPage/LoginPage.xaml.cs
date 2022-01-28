using BusinessLogicLayer.ViewModels.Pages.LoginPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
    public class FacebookLoginButton : View
    {
        public string[] Permissions { get; set; } = { "public_profile", "email", "user_birthday", "user_gender" };
        public FacebookLoginButton() : base()
        {}
        public async void OnLoginSuccess(string userID, string access_token)
        {
            await ((LoginViewModel)BindingContext).OnLoginSuccess(userID, access_token);
            await Navigation.PushModalAsync(new CreateProfileContentPage(), true);
        }
    }
}