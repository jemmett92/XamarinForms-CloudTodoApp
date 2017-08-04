using Xamarin.Forms;

namespace PrismUnityToDolistMobile.Views
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();
            {
                Label header = new Label
                {
                    Text = "WebView",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                };

                WebView webView = new WebView
                {
                    Source = new UrlWebViewSource
                    {
                        Url = "http://blog.xamarin.com/",
                    },
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                // Accomodate iPhone status bar.
                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

                // Build the page.
                this.Content = new StackLayout
                {
                    Children =
                {
                    header,
                    webView
                }
                };
            }
        }
    }
}