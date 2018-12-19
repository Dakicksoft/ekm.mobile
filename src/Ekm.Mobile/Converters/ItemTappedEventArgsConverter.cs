using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ekm.Mobile.Converters
{
  public class ItemTappedEventArgsConverter : IValueConverter, IMarkupExtension
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var itemTappedEventArgs = value as ItemTappedEventArgs;
      if (itemTappedEventArgs == null)
      {
        throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));
      }
      return itemTappedEventArgs.Item;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
      return this;
    }
  }
}