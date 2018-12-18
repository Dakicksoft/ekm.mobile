using System;
using System.Net.Http;
using System.Threading.Tasks;
using DryIoc;
using Ekm.Mobile.Logging;
using Ekm.Mobile.Services.Connectivity;
using Ekm.Mobile.Services.Dialog;
using OperationResult;
using Prism.Ioc;
using static OperationResult.Helpers;

namespace Ekm.Mobile.Helpers
{
    public class TaskHelper
    {
        private readonly IConnectivityService connectivityService;
        private readonly IDialogService dialogService;
        private readonly ILoggingService loggingService;

        private Action whenStarting;
        private Action whenFinished;

        private TaskHelper()
        {
            loggingService = Prism.PrismApplicationBase.Current.Container.Resolve<ILoggingService>();
            connectivityService = Prism.PrismApplicationBase.Current.Container.Resolve<IConnectivityService>();
            dialogService = App.Current.Container.Resolve<IDialogService>();
        }

        public static TaskHelper Create()
        {
            return new TaskHelper();
        }

        public TaskHelper WhenStarting(Action action)
        {
            whenStarting = action;

            return this;
        }

        public TaskHelper WhenFinished(Action action)
        {
            whenFinished = action;

            return this;
        }

        public async Task<Status> TryWithErrorHandlingAsync(
            Task task,
            Func<Exception, Task<bool>> customErrorHandler = null)
        {
            var taskWrapper = new Func<Task<object>>(() => WrapTaskAsync(task));
            var result = await TryWithErrorHandlingAsync(taskWrapper(), customErrorHandler);

            if (result)
            {
                return Ok();
            }

            return Error();
        }

        public async Task<Result<T>> TryWithErrorHandlingAsync<T>(
            Task<T> task,
            Func<Exception, Task<bool>> customErrorHandler = null)
        {
            whenStarting?.Invoke();

            if (!connectivityService.IsThereInternet)
            {
                loggingService?.Warning("There's no Internet access");
                return Error();
            }

            try
            {
                T actualResult = await task;
                return Ok(actualResult);
            }
            catch (HttpRequestException exception)
            {
                loggingService?.Warning($"{exception}");

                if (customErrorHandler == null || !await customErrorHandler?.Invoke(exception))
                {
                    await dialogService.ShowAlertAsync(
                        Resources.AppResources.AlertTitleUnexpectedError,
                        Resources.AppResources.AlertMessageInternetError,
                        Resources.AppResources.AlertOKEllipsis);
                }
            }
            catch (TaskCanceledException exception)
            {
                loggingService?.Debug($"{exception}");
            }
            catch (Exception exception)
            {
                loggingService?.Error(exception);

                if (customErrorHandler == null || !await customErrorHandler?.Invoke(exception))
                {
                    await dialogService.ShowAlertAsync(
                        Resources.AppResources.AlertTitleUnexpectedError,
                        Resources.AppResources.AlertMessageInternetError,
                        Resources.AppResources.AlertOKEllipsis);

                }
            }
            finally
            {
                whenFinished?.Invoke();
            }

            return Error();
        }

        private async Task<object> WrapTaskAsync(Task innerTask)
        {
            await innerTask;

            return new object();
        }
    }
}
