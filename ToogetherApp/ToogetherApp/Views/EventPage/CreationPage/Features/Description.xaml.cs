using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Description : ContentView, IFeatureContent
    {
        public Description()
        {
            InitializeComponent();
            editor.FontAttributes = FontAttributes.Bold;
        }
        public void OnIconClicked(string classID)
        {
            switch (classID)
            {
                case "Bold":
                    System.Console.WriteLine("Bold");
                    break;
                case "Italic":
                    System.Console.WriteLine("Italic");
                    break;
                case "Underline":
                    System.Console.WriteLine("Underline");
                    break;
                case "Color":
                    System.Console.WriteLine("Color");
                    break;
                case "Front":
                    System.Console.WriteLine("Font");
                    break;
            }
        }
    }
}