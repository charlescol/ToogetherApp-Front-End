using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Text;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToogetherApp.Droid.Renderer;
using ToogetherApp.Views.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RichTextEditor), typeof(CustomRichTextEditorRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer
{
    public class CustomRichTextEditorRenderer_Droid : EditorRenderer
    {
        private bool _isBoldEnabled = false;
        public CustomRichTextEditorRenderer_Droid(Context context) : base(context) 
        { 
        }
        public void SetTextBold()
        {
            _isBoldEnabled = !_isBoldEnabled;
            var span = HtmlCompat.FromHtml("<b>" + Control.Text + "</b>", HtmlCompat.FromHtmlModeLegacy);
            Control.SetText(span, TextView.BufferType.Spannable);
            Console.WriteLine(span);
            //if(_isBoldEnabled)
            //{df
            //    Control.Typeface = Android.Graphics.Typeface.DefaultBold;
            //}
            //this.Control.SetTextColor(Android.Graphics.Color.Red);

        }
        public void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //if (e.OldTextValue != null)
            //{
            //    var newText = e.NewTextValue.Replace(e.OldTextValue, "");
            //    SpannableString ss = new SpannableString(Control.Text);
            //    StyleSpan boldSpan = new StyleSpan(Android.Graphics.TypefaceStyle.Bold);
            //    ss.SetSpan(boldSpan, e.OldTextValue.Length - 1, e.OldTextValue.Length, SpanTypes.ExclusiveExclusive);
            //    Control.SetText(ss);
            //}

            //ISpannable spannable = new SpannableString(e.NewTextValue);

            //spannable.SetSpan(Android.Graphics.Typeface.DefaultBold, e.NewTextValue.Length, Control.Text.Length, SpanTypes.ExclusiveInclusive);
            //Control.SetText(spannable, TextView.BufferType.Spannable);

            
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove bottom line
                Control.SetBackground(null);
            }
            if (e.NewElement != null)
            {
                var editor = e.NewElement as RichTextEditor;
                if(editor != null)
                {
                    editor.HandlerTextBold += SetTextBold;
                    editor.TextChanged += OnTextChanged;
                }
                
                
            }
            if (e.OldElement != null)
            {
                ((RichTextEditor)e.OldElement).HandlerTextBold -= SetTextBold;
            }
        }
    }
}