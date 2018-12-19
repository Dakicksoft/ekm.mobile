﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace Ekm.Mobile.Converters
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
                return value.ToString();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doub;
            if (double.TryParse(value as string, out doub))
                return doub;
            return value;
        }
    }
}
