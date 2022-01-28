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
    public partial class EventFocusWindows : ContentView
    {
        public delegate void CurrentScrolled(float height);
        public event CurrentScrolled HandlerCurrentScrolled;

        public EventFocusWindows()
        {
            InitializeComponent();
        }
        void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            HandlerCurrentScrolled?.Invoke((float) e.ScrollY);
        }
        public async void OnEventConsulted(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EventMainPage(), false);
        }
    }
}