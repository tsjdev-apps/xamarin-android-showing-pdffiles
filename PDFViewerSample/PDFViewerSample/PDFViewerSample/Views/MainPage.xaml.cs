using PDFViewerSample.Utils;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PDFViewerSample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LauncherButtonOnClicked(object sender, EventArgs e)
        {
            var filePath = await DownloadPdfFileAsync();

            if (filePath != null)
            {
                await Launcher.OpenAsync(new OpenFileRequest
                {
                    File = new ReadOnlyFile(filePath)
                });
            }
        }

        private async void GoogleDriveViewerButtonOnClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GoogleDriveViewerPage());
        }

        private async void PdfJsButtonOnClicked(object sender, EventArgs e)
        {
            var filePath = await DownloadPdfFileAsync();

            if (filePath != null)
                await Application.Current.MainPage.Navigation.PushAsync(new PdfJsPage(filePath));
        }

        private async Task<string> DownloadPdfFileAsync()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "test.pdf");

            if (File.Exists(filePath))
                return filePath;

            var httpClient = new HttpClient();
            var pdfBytes = await httpClient.GetByteArrayAsync(Statics.PdfUrl);

            try
            {
                File.WriteAllBytes(filePath, pdfBytes);

                return filePath;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

            return null;
        }
    }
}
