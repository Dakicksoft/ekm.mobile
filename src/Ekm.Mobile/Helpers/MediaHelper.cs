//using System.Threading.Tasks;
//using Acr.UserDialogs;
//using Ekm.Mobile.Language;
//using Ekm.Mobile.Services.Media;
//using Plugin.Permissions;
//using Plugin.Permissions.Abstractions;
//using Prism.Services;

//namespace Ekm.Mobile.Helpers
//{
//  public static class MediaHelper
//  {
//    private static LocalizedResources Resources
//    {
//      get;
//      set;
//    }

//    private static IMediaService MediaService
//    {
//      get;
//      set;
//    }

//    public static async Task<bool> CheckCameraPermissionAndStatusAsync()
//    {

//      if (Resources == null)
//        Resources = new LocalizedResources(typeof(Resx.AppResources), Settings.AppLanguage);

//      if (MediaService == null)
//        MediaService = new MediaService();

//      bool result = true;

//      var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
//      var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

//      if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
//      {
//        var results =
//          await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
//        cameraStatus = results[Permission.Camera];
//        storageStatus = results[Permission.Storage];
//      }

//      if (cameraStatus != PermissionStatus.Granted && storageStatus != PermissionStatus.Granted)
//      {
//        await UserDialogs.Instance.AlertAsync(Resources["CameraPermissionStatus"],
//          Resources["ShowAlertWarning"], Resources["ShowAlertButtonOkText"]);
//        result = false;
//      }

//      if (!MediaService.IsCameraAvailable || !MediaService.IsTakePhotoSupported)
//      {
//        await UserDialogs.Instance.AlertAsync(Resources["CameraAvailable"], Resources["ShowAlertWarning"],
//          Resources["ShowAlertButtonOkText"]);
//        result = false;
//      }

//      return result;
//    }
//  }
//}
