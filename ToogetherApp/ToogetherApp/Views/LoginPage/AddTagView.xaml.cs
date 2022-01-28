using BusinessLogicLayer.ViewModels.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTagView : ContentView
    {
        public AddTagView(ProfileViewModel context)
        {
            InitializeComponent();
            BindingContext = context;            
        }
        public void OnEntryCompleted(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                ((ProfileViewModel)BindingContext).AddTagCommand.Execute(entry.Text);
                entry.Text = "";
            }
        }
        public void OnProfileCompleted(object sender, EventArgs e)
        {
            if (((ProfileViewModel)BindingContext).PublishData())
            {
                Application.Current.MainPage = new AppShell();
            }

        }
    }
}