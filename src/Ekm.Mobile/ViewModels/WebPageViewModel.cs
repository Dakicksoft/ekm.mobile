using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekm.Mobile.ViewModels
{
    public class WebPageViewModel : ViewModelBase
    {
        public WebPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
                               : base(navigationService, pageDialogService, deviceService)
        {
        }

        public string Url { get => @"https://api.ekm.net/connect/authorize?client_id=42d5671f-3549-4d67-be7e-1256b527fc0f&scope=tempest.orders.read tempest.customers.write&redirect_uri=http://www.dakicksoft.com&state=http://www.dakicksoft.com&prompt=login&response_type=code"; }
    }
}
