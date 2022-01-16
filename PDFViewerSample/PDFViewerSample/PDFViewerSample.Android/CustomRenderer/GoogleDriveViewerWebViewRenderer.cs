using Android.Content;
using PDFViewerSample.Controls;
using PDFViewerSample.Droid.CustomRenderer;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GoogleDriveViewerWebView), typeof(GoogleDriveViewerWebViewRenderer))]
namespace PDFViewerSample.Droid.CustomRenderer
{
    public class GoogleDriveViewerWebViewRenderer : WebViewRenderer
    {
        private GoogleDriveViewerWebView _googleDriveViewerWebView;

        public GoogleDriveViewerWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            _googleDriveViewerWebView = Element as GoogleDriveViewerWebView;

            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.AllowUniversalAccessFromFileURLs = true;

            if (_googleDriveViewerWebView.Uri != null)
                Control.LoadUrl(string.Format("https://drive.google.com/viewerng/viewer?url={0}", WebUtility.UrlEncode(_googleDriveViewerWebView.Uri)));
        }

        protected override void OnElementPropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(GoogleDriveViewerWebView.Uri) && _googleDriveViewerWebView.Uri != null)
                Control.LoadUrl(string.Format("https://drive.google.com/viewerng/viewer?url={0}", WebUtility.UrlEncode(_googleDriveViewerWebView.Uri)));
        }
    }
}