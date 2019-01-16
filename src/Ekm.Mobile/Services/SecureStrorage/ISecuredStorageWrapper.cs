using System.Threading.Tasks;

namespace Ekm.Mobile.Services.SecureStrorage
{
    public interface ISecuredStorageWrapper
    {
        Task<string> GetAuthToken();
        Task SetAuthToken(string token);


        Task<string> GetAuthorizationCode();
        Task SetAuthorizationCode(string code);
            
    }
}
