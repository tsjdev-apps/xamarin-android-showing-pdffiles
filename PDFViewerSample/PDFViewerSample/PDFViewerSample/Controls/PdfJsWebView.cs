using Xamarin.Forms;

namespace PDFViewerSample.Controls
{
    public class PdfJsWebView : WebView
    {
        public static readonly BindableProperty UriProperty =
           BindableProperty.Create(nameof(Uri), typeof(string), typeof(PdfJsWebView), default(string));

        public string Uri
        {
            get => (string)GetValue(UriProperty);
            set => SetValue(UriProperty, value);
        }
    }
}
