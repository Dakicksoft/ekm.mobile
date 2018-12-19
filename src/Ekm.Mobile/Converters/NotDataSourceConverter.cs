using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace Ekm.Mobile.Converters
{
  public class NotDataSourceConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return true;

      return ((IList)value).Count <= 0 ? true : (object)false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
