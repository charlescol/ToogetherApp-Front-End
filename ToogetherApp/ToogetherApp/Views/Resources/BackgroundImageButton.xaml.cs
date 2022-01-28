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
    public partial class BackgroundImageButton : AbsoluteLayout
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(BackgroundImageButton), string.Empty);
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(string), typeof(BackgroundImageButton), string.Empty);
        public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create("ClickedCommand", typeof(ICommand), typeof(BackgroundImageButton));
        public BackgroundImageButton()
        {
            InitializeComponent();
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
        public ICommand ClickedCommand
        {
            get { return (ICommand)GetValue(ClickedCommandProperty); }
            set { SetValue(ClickedCommandProperty, value); }
        }
        public void OnClicked(object sender, EventArgs e)
        {
            if (ClickedCommand != null && ClickedCommand.CanExecute(null))
            {
                ClickedCommand.Execute(null);
            }
        }
    }
}