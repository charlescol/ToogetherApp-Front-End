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
    public partial class MapLocation : ContentView, IFeatureContent
    {
        public MapLocation()
        {
            InitializeComponent();
        }

        public void OnIconClicked(string classID)
        {
            switch (classID)
            {
                case "Location":
                    System.Console.WriteLine("Location");
                    break;
                case "Pin":
                    System.Console.WriteLine("Pin");
                    break;
            }
        }
    }
}