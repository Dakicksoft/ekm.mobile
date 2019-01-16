using System.Threading.Tasks;

namespace Ekm.Mobile.Services.SecureStrorage
{

    public class SecuredStorageWrapper : ISecuredStorageWrapper
    {
        public Task<string> GetAuthorizationCode() => Xamarin.Essentials.SecureStorage.GetAsync(StorageKey.AuthorizationCode);

        public Task<string> GetAuthToken() => Xamarin.Essentials.SecureStorage.GetAsync(StorageKey.Token);

        public Task SetAuthorizationCode(string code) => Xamarin.Essentials.SecureStorage.SetAsync(StorageKey.AuthorizationCode, code);

        public Task SetAuthToken(string token) => Xamarin.Essentials.SecureStorage.SetAsync(StorageKey.Token, token);
    }
}
