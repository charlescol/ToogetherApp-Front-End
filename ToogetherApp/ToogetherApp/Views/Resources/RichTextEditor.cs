using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ToogetherApp.Views.Resources
{
    public class RichTextEditor : Editor
    {
        // Event
        public delegate void TextBold();
        // Event Handlers
        public event TextBold HandlerTextBold;
        public RichTextEditor() : base()
        { }
        public void SetTextBold()
        {
            HandlerTextBold?.Invoke();
        }
    }
}
