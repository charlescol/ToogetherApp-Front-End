using ServiceLayer;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessLogicLayer.ViewModels.Pages.LoginPage
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {}
        public async Task OnLoginSuccess(string userID, string access_token)
        {
            var fb_user = await LoginService.GetfacebookProfileAsync(userID, access_token);
        }
        public void OnLoginError(string message) {}
        public void OnLoginCancel() { }
    }
}
