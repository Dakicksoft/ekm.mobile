using System.Threading.Tasks;
using Ekm.Mobile.Extensions;
using Ekm.Mobile.Services.Dialog;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Ekm.Mobile.ViewModels
{
    /// <summary>
    /// For more information: https://docs.google.com/document/d/1Y26QJmrXi6NBID34E4M6G9D0_A-jLiNtGb9kHvGw69A/edit
    /// </summary>
    public class WebPageViewModel : ViewModelBase
    {

        #region Fields

        private readonly IDialogService _dialogService;

        #endregion Fields

        #region Ctor

        public WebPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService, IDialogService dialogService)
                             : base(navigationService, pageDialogService, deviceService)
        {

            _dialogService = dialogService;
        }

        #endregion Ctor


        #region Commands
        public DelegateCommand<object> NavigatingCommand => new DelegateCommand<object>(async (obj) => await ExecuteNavigating(obj));

        public DelegateCommand<object> NavigatedCommand => new DelegateCommand<object>((obj) => { _dialogService.HideLoading(); base.IsBusy = false; });

        #endregion Commands

        #region Vms

        public string Url { get => $"{Helpers.AppConstants.GatewayUrl}/connect/authorize?client_id={Helpers.AppConstants.ClientKey}&scope={Helpers.AppConstants.RequiredScopes.ToConcatenatedString(s => s.Key, " ")}&redirect_uri={Helpers.AppConstants.RedirectUri}&state={Helpers.AppConstants.RedirectUri}&prompt=login&response_type=code"; }

        #endregion Vms

        #region Methods
        private async Task ExecuteNavigating(object obj)
        {
            base.IsBusy = true;

            _dialogService.ShowLoading("", Acr.UserDialogs.MaskType.Black);

            var args = (Xamarin.Forms.WebNavigatingEventArgs)obj;

            if (args.Url.StartsWith(Helpers.AppConstants.RedirectUri))
            {
                await base._navigationService.GoBackAsync(useModalNavigation: true);
            }
        }

        #endregion Methods
    }
}
