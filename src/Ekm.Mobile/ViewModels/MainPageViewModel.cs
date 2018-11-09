using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Ekm.Mobile.Resources;

namespace Ekm.Mobile.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                             IDeviceService deviceService)
        : base(navigationService, pageDialogService, deviceService)
    {
      Title = AppResources.MainPageTitle;
    }

    public override void OnNavigatingTo(INavigationParameters parameters)
    {
      // TODO: Implement your initialization logic
    }

    public override void OnNavigatedFrom(INavigationParameters parameters)
    {
      // TODO: Handle any final tasks before you navigate away
    }

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
      switch (parameters.GetNavigationMode())
      {
        case NavigationMode.Back:
          // TODO: Handle any tasks that should occur only when navigated back to
          break;
        case NavigationMode.New:
          // TODO: Handle any tasks that should occur only when navigated to for the first time
          break;
      }

      // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
    }
  }
}