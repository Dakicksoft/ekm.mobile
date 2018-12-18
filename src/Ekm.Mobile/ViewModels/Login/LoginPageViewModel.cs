using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Ekm.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
        }
        public DelegateCommand SignInCommand => new DelegateCommand(async () => await base._navigationService.NavigateAsync(Screens.WebPage, useModalNavigation: true));


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await System.Threading.Tasks.Task.Delay(4000);

            await base.XSnackService.ShowMessageAsync("Deneme meneme meneme");
        }
    }
}
