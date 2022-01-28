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
    public partial class Actors : ContentView, IFeatureContent
    {
        public Actors()
        {
            InitializeComponent();
        }

        public void OnIconClicked(string classID)
        {
            switch (classID)
            {
                case "Add":
                    System.Console.WriteLine("Add");
                    break;
            }
        }
    }
}