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
    public partial class Presentation : ContentView, IFeatureContent
    {
        public Presentation()
        {
            InitializeComponent();
        }

        public void OnIconClicked(string classID)
        {
            switch (classID)
            {
                case "Photo":
                    System.Console.WriteLine("Photo");
                    break;
                case "Gallery":
                    System.Console.WriteLine("Gallery");
                    break;
            }
        }
    }
}