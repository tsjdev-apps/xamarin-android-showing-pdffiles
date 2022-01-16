using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDFViewerSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfJsPage : ContentPage
    {
        public PdfJsPage(string url)
        {
            InitializeComponent();

            PdfJsWebView.Uri = url;
        }
    }
}