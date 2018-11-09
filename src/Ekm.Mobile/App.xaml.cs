using System;
using System.Threading.Tasks;
using Ekm.Mobile.Resources;
using Ekm.Mobile.Services;
using Ekm.Mobile.Views;
using Plugin.Multilingual;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using DryIoc;
using Prism.DryIoc;
using FFImageLoading.Helpers;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using BarcodeScanner;
using Prism.Logging;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Ekm.Mobile
{
  public partial class App
  {
    /* 
     * NOTE: 
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor. 
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */
    public App()
        : this(null)
    {
    }

    public App(IPlatformInitializer initializer)
        : this(initializer, false)
    {
    }

    public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
        : base(initializer, setFormsDependencyResolver)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();
#if DEBUG
            // Handle Xamarin Form Logging events such as Binding Errors
            Log.Listeners.Add(new TraceLogListener());
#endif

      LogUnobservedTaskExceptions();
      AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

      await NavigationService.NavigateAsync("SplashScreenPage");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register the Popup Plugin Navigation Service
      containerRegistry.RegisterPopupNavigationService();

      // NOTE: Uses a Popup Page to contain the Scanner. You can optionally register 
      // the ContentPageBarcodeScannerService if you prefer a full screen approach.
      containerRegistry.RegisterSingleton<IBarcodeScannerService, PopupBarcodeScannerService>();

      // Navigating to "TabbedPage?createTab=ViewA&createTab=ViewB&createTab=ViewC will generate a TabbedPage
      // with three tabs for ViewA, ViewB, & ViewC
      // Adding `selectedTab=ViewB` will set the current tab to ViewB
      containerRegistry.RegisterForNavigation<TabbedPage>();
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage>();
      containerRegistry.RegisterForNavigation<SplashScreenPage>();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle IApplicationLifecycle
      base.OnSleep();

      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle IApplicationLifecycle
      base.OnResume();

      // Handle when your app resumes
    }

    private void LogUnobservedTaskExceptions()
    {
      TaskScheduler.UnobservedTaskException += (sender, e) =>
      {
        Container.Resolve<ILoggerFacade>().Log(e.Exception.ToString(), Category.Exception, Priority.None);
      };
    }
  }
}
