
namespace Ekm.Mobile.Models
{
    public class Notification
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public NotificationType Type { get; set; }
    }

    public enum NotificationType
    {
        Confirmation, Notification, Success, Error, Warning
    }
}
