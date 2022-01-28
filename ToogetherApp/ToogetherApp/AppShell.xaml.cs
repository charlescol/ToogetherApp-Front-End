
using Xamarin.Forms;

namespace ToogetherApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // set first tab opened 
            CurrentItem = first_tab;
        }

    }
}
