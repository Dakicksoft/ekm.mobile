using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ekm.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            TheWebView.Source = "https://api.ekm.net/connect/authorize?client_id=42d5671f-3549-4d67-be7e-1256b527fc0f&scope=tempest.orders.read tempest.customers.write&redirect_uri=http://www.dakicksoft.com&state=http://www.dakicksoft.com&prompt=login&response_type=code";

            TheWebView.Navigating += async (sender, args) => {
              //  args.Cancel = true; // prevents the webview navigation from handling

                System.Diagnostics.Debug.WriteLine("Received");
            };

        }
    }
}
