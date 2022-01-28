using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTitle : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomTitle), string.Empty);
        public CustomTitle()
        {
            BindingContext = this;
            InitializeComponent();
        }
        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}