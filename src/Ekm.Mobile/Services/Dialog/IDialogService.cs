using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Ekm.Mobile.Enums;

namespace Ekm.Mobile.Services.Dialog
{
    public interface IDialogService
	{
	
    Task ShowAlertAsync(string message, string title, string buttonLabel);

   // void ShowError(string message, int timeout=2000);

    void ShowLoading(string title = null, MaskType? maskType = default(MaskType?));

    void HideLoading();
    
    void ShowSuccess(string message, int timeoutMillis = 2000);

    Task<bool> ConfirmAsync(ConfirmConfig config, CancellationToken? cancelToken = default(CancellationToken?));
    
    Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = default(CancellationToken?));
	
    void ShowNotifaciton(ToastNotificationTypeEnum type, string message, int delay=2000);

	  void Progress(string title,bool show,MaskType? maskType);

	  Task<PromptResult> PromptAsync(string message, string title, string okText, string cancelText, string placeHolder,
	    InputType inputType);

	}
}
