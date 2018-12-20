using Ekm.Mobile.Extensions;
using Ekm.Mobile.Services.Authentication;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Ekm.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Fields

        private readonly IAuthenticate _authenticate;

        #endregion Fields

        #region Ctor

        public LoginPageViewModel(IAuthenticate authenticate,INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            _authenticate = authenticate;
        }

        #endregion Ctor

        #region Commands

        public DelegateCommand SignInCommand => new DelegateCommand(async () => await base._navigationService.NavigateAsync(Screens.WebPage, useModalNavigation: true));

        #endregion Commands

        #region Methods

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var code = await Helpers.SecureStorage.Get(Helpers.StorageKey.AuthorizationCode).ConfigureAwait(false);

            if (code.IsNullOrEmpty())
            {
                var token = await _authenticate.Token().ConfigureAwait(false);
            }
        }

        #endregion Methods
    }
}
