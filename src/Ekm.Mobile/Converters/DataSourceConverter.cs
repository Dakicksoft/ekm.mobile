using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace Ekm.Mobile.Converters
{
  public class DataSourceConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return false;

      return ((IList)value).Count <= 0 ? false : (object)true;

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
