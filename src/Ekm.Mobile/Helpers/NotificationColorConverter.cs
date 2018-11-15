using Ekm.Mobile.Models;
using System;
using Xamarin.Forms;

namespace Ekm.Mobile
{
	public class NotificationColorConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var notificationType = (NotificationType)value;
			string resourceName;

			switch (notificationType)
			{
				case NotificationType.Confirmation:
					resourceName = "OkColor";
					break;

				case NotificationType.Notification:
					resourceName = "NotificationColor";
					break;

				case NotificationType.Success:
					resourceName = "OkColor";
					break;

				case NotificationType.Warning:
					resourceName = "WarningColor";
					break;

				default: // Error
					resourceName = "ErrorColor";
					break;
			}

			object result;

			if (Application.Current.Resources != null && Application.Current.Resources.TryGetValue(resourceName, out result))
			{
				return result;
			}

			return Color.Default;
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException ();
		}
	}
}