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
    public partial class Date : ContentView, IFeatureContent
    {
        public Date()
        {
            InitializeComponent();
        }

        public void OnIconClicked(string classID)
        {
            switch (classID)
            {
                case "Beginning":
                    System.Console.WriteLine("Beginning");
                    break;
                case "End":
                    System.Console.WriteLine("End");
                    break;
            }
        }
    }
}