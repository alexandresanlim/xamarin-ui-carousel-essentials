using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Xamarin.Essentials.Permissions;

namespace App.CardTools.Services.DeviceApi
{
    public abstract class PermissionService
    {
        public async static Task<Xamarin.Essentials.PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission) where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();

            if (status != Xamarin.Essentials.PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }

        public static async Task RequirePermissionToExecute(Func<Task> task, BasePermission permission, Func<Task> taskToNotPermission = null)
        {
            var status = await PermissionService.CheckAndRequestPermissionAsync(permission);

            if (status != Xamarin.Essentials.PermissionStatus.Granted)
            {
                //await App.Current.MainPage.DisplayAlert("Não é possive continuar, permissão não concedida");

                if (taskToNotPermission != null)
                    await taskToNotPermission.Invoke();

                return;
            }

            await task.Invoke();
        }

    }
}
