using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Ekm.Mobile.Extensions;
using System;
using System.Threading.Tasks;

namespace Ekm.Mobile.ViewModels
{
    public class WebPageViewModel : ViewModelBase
    {
        public WebPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
                               : base(navigationService, pageDialogService, deviceService)
        {
        }
        public DelegateCommand<object> NavigatingCommand => new DelegateCommand<object>(async (obj) =>await ExecuteNavigating(obj));

        private async Task ExecuteNavigating(object obj)
        {
            var args = (Xamarin.Forms.WebNavigatingEventArgs)obj;

            if (args.Url.StartsWith(Helpers.AppConstants.RedirectUri))
            {
                await base._navigationService.GoBackAsync(useModalNavigation: true);
            }
        }

        public string Url { get => $"https://api.ekm.net/connect/authorize?client_id={Helpers.AppConstants.ClientKey}&scope={Helpers.AppConstants.RequiredScopes.ToConcatenatedString(s=>s.Key," ")}&redirect_uri={Helpers.AppConstants.RedirectUri}&state={Helpers.AppConstants.RedirectUri}&prompt=login&response_type=code"; }
    }
}
