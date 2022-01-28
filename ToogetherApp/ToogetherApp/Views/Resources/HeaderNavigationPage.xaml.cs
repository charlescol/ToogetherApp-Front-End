using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderNavigationPage : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(HeaderNavigationPage), string.Empty);
        public static readonly BindableProperty TitleVisibleProperty = BindableProperty.Create("TitleVisible", typeof(bool), typeof(CustomTitle), true);
        public HeaderNavigationPage()
        {
            InitializeComponent();
        }
        public async void OnQuitPage(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public bool TitleVisible
        {
            get => (bool)GetValue(TitleVisibleProperty);
            set => SetValue(TitleVisibleProperty, value);
        }
    }
}