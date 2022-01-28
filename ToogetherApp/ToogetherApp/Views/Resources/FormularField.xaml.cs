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
    public partial class FormularField : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(FormularField), string.Empty);
        public static readonly BindableProperty SourceProperty = BindableProperty.Create("Source", typeof(string), typeof(FormularField), string.Empty);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(FormularField), Color.Black);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(FormularField), Color.Black);
        public static readonly BindableProperty EditorTextColorProperty = BindableProperty.Create("EditorTextColor", typeof(Color), typeof(FormularField), Color.Black);
        public FormularField() : base()
        {
            BindingContext = this;
            InitializeComponent();
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        public Color EditorTextColor
        {
            get => (Color)GetValue(EditorTextColorProperty);
            set => SetValue(EditorTextColorProperty, value);
        }
    }
}