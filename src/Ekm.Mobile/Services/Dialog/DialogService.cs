using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Ekm.Mobile.Enums;

namespace Ekm.Mobile.Services.Dialog
{
    public class DialogService : IDialogService
  {

    public void HideLoading()
    {
      UserDialogs.Instance.HideLoading();
    }

    public Task ShowAlertAsync(string message, string title, string buttonLabel)
    {
      return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
    }

    public void ShowLoading(string title = null, MaskType? maskType = null)
    {
      UserDialogs.Instance.ShowLoading(title, maskType);

    }

    public void ShowSuccess(string message, int timeoutMillis = 2000)
    {
      var config = new ActionSheetConfig();
      config.Cancel = new ActionSheetOption("Cancel");
      //config.Destructive = new ActionSheetOption("Desc");
      config.ItemIcon = "ic_alert_circle_grey600_24dp";
      config.Message = message;
      //config.Title = "S";
      UserDialogs.Instance.ActionSheet(config);
    }

    public Task<bool> ConfirmAsync(ConfirmConfig config, CancellationToken? cancelToken = default(CancellationToken?))
    {
      return UserDialogs.Instance.ConfirmAsync(config, cancelToken);
    }

    public Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = default(CancellationToken?))
    {
      return UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText, cancelToken);
    }

    public void ShowNotifaciton(ToastNotificationTypeEnum type, string message, int delay = 2000)
    {
      var config = new ToastConfig(message);
      config.SetPosition(ToastPosition.Bottom);
      config.SetDuration(delay);
      config.SetMessageTextColor(System.Drawing.Color.White);

      switch (type)
      {
        case ToastNotificationTypeEnum.Error:
          config.SetBackgroundColor(System.Drawing.Color.DarkRed);
          break;
        case ToastNotificationTypeEnum.Success:
          config.SetBackgroundColor(System.Drawing.Color.Green);
          break;
        case ToastNotificationTypeEnum.Info:
          config.SetBackgroundColor(System.Drawing.Color.Orange);
          break;
        case ToastNotificationTypeEnum.Warning:
          config.SetBackgroundColor(System.Drawing.Color.MediumVioletRed);
          break;
      }

      UserDialogs.Instance.Toast(config);
    }

    public void Progress(string title, bool show, MaskType? maskType = null)
    {
      UserDialogs.Instance.Progress(title, null, null, show, maskType);
    }

    public async Task<PromptResult> PromptAsync(string message, string title, string okText, string cancelText, string placeHolder, InputType inputType)
    {
      var promptResult=await  UserDialogs.Instance.PromptAsync(message, title, okText, cancelText, placeHolder, inputType);
      return promptResult;
    }
  }
}
