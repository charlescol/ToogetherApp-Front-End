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
    public partial class FeatureView : ContentView
    {
        public View CurrentView { get; set; } = null;
        public string Title { get; set; }
        /* Event */
        /* Event */
        public delegate void ClickedEvent(string classID);
        /* Event Handler */
        public event ClickedEvent HandlerClickedEvent;
        public FeatureView()
        {
            InitializeComponent();
        }
        public void AddToGrid(View view, int row, int column)
        {
            toolBar_grid.Children.Add(view, row, column);
        }
        public void ClearGrid()
        {
            toolBar_grid.Children.Clear();
        }
        public void AddToContent(View content)
        {
            main_stack_layout.Children.Add(content);
            CurrentView = content;
            main_stack_layout.Children.Add(content);
        }
        public void OnIconClicked(object sender, System.EventArgs args)
        {
            HandlerClickedEvent?.Invoke(((View)sender).ClassId);
        }
    }
}