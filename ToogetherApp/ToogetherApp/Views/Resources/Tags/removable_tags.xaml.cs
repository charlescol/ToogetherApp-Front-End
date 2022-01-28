using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Removable_tags : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(Removable_tags), string.Empty);
        public static readonly BindableProperty RemovedCommandProperty = BindableProperty.Create("RemovedCommand", typeof(ICommand), typeof(Removable_tags));
        public Removable_tags()
        {
            InitializeComponent();
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public ICommand RemovedCommand
        {
            get { return (ICommand)GetValue(RemovedCommandProperty); }
            set { SetValue(RemovedCommandProperty, value); }
        }
        public void OnTagRemoved(object sender, EventArgs e)
        {
            if (RemovedCommand != null && RemovedCommand.CanExecute(Text))
            {
                RemovedCommand.Execute(Text);
            }
        }
    }
}

