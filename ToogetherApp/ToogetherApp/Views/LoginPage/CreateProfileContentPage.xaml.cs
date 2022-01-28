using BusinessLogicLayer.ViewModels.Pages.LoginPage;
using BusinessLogicLayer.ViewModels.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProfileContentPage : ContentPage
    {
        public ObservableCollection<ContentView> Views { get; set; } = new ObservableCollection<ContentView>();
        ProfileViewModel ProfileViewModel { get; set; } = new ProfileViewModel();
        public ProfileViewModel _context { get; set; }  = new ProfileViewModel();
        public CreateProfileContentPage()
        {
            BindingContext = _context;
            InitializeComponent();
            Views.Add(new AddProfilePictureView(_context));
            Views.Add(new AddDescriptionView(_context));
            Views.Add(new AddTagView(_context));
        }
    }
}