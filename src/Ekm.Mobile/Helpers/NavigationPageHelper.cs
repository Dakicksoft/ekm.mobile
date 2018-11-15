using Xamarin.Forms;

namespace Ekm.Mobile.Helpers
{
  public static class NavigationPageHelper
  {
    public static NavigationPage Create(Page page)
    {
      return new NavigationPage(page) { BarTextColor = Color.White };
    }
  }
}
