using Prism;
using Prism.Ioc;

namespace Ekm.Mobile.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
            containerRegistry.Register<Plugin.XSnack.IXSnack, Plugin.XSnack.XSnackImplementation>();
        }
    }
}
