
namespace Ekm.Mobile.Services.Connectivity
{
    internal class ConnectivityService : IConnectivityService
    {
        public bool IsThereInternet => Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet;
    }
}
