using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToogetherApp.Views.Resources.Event;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsFeed : ContentView
    {
        public ObservableCollection<EventNewsfeed> Views { get; set; } = new ObservableCollection<EventNewsfeed>();
        public NewsFeed()
        {
            BindingContext = this;
            InitializeComponent();

            Views.Add(new EventNewsfeed());
            Views.Add(new EventNewsfeed());
            Views.Add(new EventNewsfeed());
        }
    }
}