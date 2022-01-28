using BusinessLogicLayer.ViewModels.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDescriptionView : ContentView
    {
        public AddDescriptionView(ProfileViewModel context)
        {
            InitializeComponent();
            BindingContext = context;
        }
        public void OnBoldCLicked(object sender, EventArgs e)
        {
            richText_editor.SetTextBold();
        }
    }
}