using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ToogetherApp.Views
{
    public struct FeatureContent
    {
        public IList<string> IconsSource;
        public IList<string> IconsClassID;
        public IList<string> IconsText;
        public string Title;
        public int Index;
        public View Content;
        public string Name;
    }
}
