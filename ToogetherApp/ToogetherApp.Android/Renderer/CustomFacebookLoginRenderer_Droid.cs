
using Android.Content;
using BusinessLogicLayer.ViewModels.Pages.LoginPage;
using Java.Lang;
using ToogetherApp.Droid.Renderer;
using ToogetherApp.Views;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(CustomFacebookLoginRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer 
{
    public class CustomFacebookLoginRenderer_Droid : ViewRenderer, IFacebookCallback
    {
        Context _context;
        bool disposed;
        public CustomFacebookLoginRenderer_Droid(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            if (Control == null)
            {
                var fbLoginBtnView = e.NewElement as FacebookLoginButton;
                var fbLoginbBtnCtrl = new Xamarin.Facebook.Login.Widget.LoginButton(_context)
                {
                    LoginBehavior = LoginBehavior.NativeWithFallback
                };

                fbLoginbBtnCtrl.SetPermissions(fbLoginBtnView.Permissions);
                fbLoginbBtnCtrl.RegisterCallback(MainActivity.CallbackManager, this);

                SetNativeControl(fbLoginbBtnCtrl);
            }
        }
        public void OnCancel()
        {
        }

        public void OnError(FacebookException error)
        {
        }

        public void OnSuccess(Object result)
        {
            var login_result = (LoginResult)result;
            ((FacebookLoginButton)Element).OnLoginSuccess(login_result.AccessToken.UserId, login_result.AccessToken.Token);
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                
                if (disposing && !this.disposed)
                {
                    if (this.Control != null)
                    {
                        (this.Control as Xamarin.Facebook.Login.Widget.LoginButton).UnregisterCallback(MainActivity.CallbackManager);
                    }
                    this.disposed = true;
                }
                base.Dispose(disposing);
            }
            catch(Exception e) { }

        }

    }
}