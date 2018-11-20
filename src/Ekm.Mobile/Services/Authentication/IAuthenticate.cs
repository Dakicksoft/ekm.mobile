using System.Threading.Tasks;

namespace Ekm.Mobile.Services.Authentication
{
    public interface IAuthenticate
    {
        Task<Auth> Token();

        Task<Auth> Refresh();
    }
}
