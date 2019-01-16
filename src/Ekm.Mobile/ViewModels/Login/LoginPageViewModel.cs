using Ekm.Mobile.Extensions;
using Ekm.Mobile.Services.Authentication;
using Ekm.Mobile.Services.SecureStrorage;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Ekm.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Fields

        private readonly IAuthenticate _authenticate;
        private readonly ISecuredStorageWrapper _securedStorageWrapper;

        #endregion Fields

        #region Ctor

        public LoginPageViewModel(IAuthenticate authenticate, 
                                  INavigationService navigationService, 
                                  IPageDialogService pageDialogService,
                                  ISecuredStorageWrapper securedStorageWrapper,
                                  IDeviceService deviceService) : 
                                  base(navigationService, pageDialogService, deviceService)
        {
            _authenticate = authenticate;
            _securedStorageWrapper = securedStorageWrapper;
        }

        #endregion Ctor

        #region Commands

        public DelegateCommand SignInCommand => new DelegateCommand(async () => await base._navigationService.NavigateAsync(Screens.WebPage, useModalNavigation: true));

        #endregion Commands

        #region Methods

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var code = await _securedStorageWrapper.GetAuthorizationCode();

            if (!code.IsNullOrEmpty())
            {
                var token = await base.TryExecuteWithLoadingIndicatorsAsync<Auth>(_authenticate.Token());
            }
        }

        #endregion Methods
    }
}
