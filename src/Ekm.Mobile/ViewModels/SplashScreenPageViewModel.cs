using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;

namespace Ekm.Mobile.ViewModels
{
    public class SplashScreenPageViewModel : ViewModelBase
    {

        #region Fields


        #endregion Fields

        #region Ctor

        public SplashScreenPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {

            base.Title = "Splash";
        }

        #endregion Ctor


        #region Commands

        #endregion Commands

        #region Vms

        #endregion Vms

        #region Methods

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            // TODO: Implement any initialization logic you need here. Example would be to handle automatic user login

            // Simulated long running task. You should remove this in your app.
            await Task.Delay(4000);

            // After performing the long running task we perform an absolute Navigation to remove the SplashScreen from
            // the Navigation Stack.
            //await _navigationService.NavigateAsync("/NavigationPage/MainPage");

            await _navigationService.NavigateAsync(Screens.LoginPage);
        }

        #endregion Methods
    }
}