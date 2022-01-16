using Android.Content;
using PDFViewerSample.Controls;
using PDFViewerSample.Droid.CustomRenderer;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PdfJsWebView), typeof(PdfJsWebViewRenderer))]
namespace PDFViewerSample.Droid.CustomRenderer
{
    public class PdfJsWebViewRenderer : WebViewRenderer
    {
        private PdfJsWebView _pdfJsWebView;

        public PdfJsWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            _pdfJsWebView = Element as PdfJsWebView;

            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.BuiltInZoomControls = true;
            Control.Settings.AllowContentAccess = true;
            Control.Settings.AllowFileAccess = true;
            Control.Settings.AllowFileAccessFromFileURLs = true;
            Control.Settings.AllowUniversalAccessFromFileURLs = true;

            if (_pdfJsWebView.Uri != null)
                Control.LoadUrl($"file:///android_asset/pdfjs/web/viewer.html?file={WebUtility.UrlEncode(_pdfJsWebView.Uri)}");
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(PdfJsWebView.Uri) && _pdfJsWebView.Uri != null)
                Control.LoadUrl($"file:///android_asset/pdfjs/web/viewer.html?file={WebUtility.UrlEncode(_pdfJsWebView.Uri)}");
        }
    }
}