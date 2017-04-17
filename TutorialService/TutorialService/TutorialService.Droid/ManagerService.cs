
using System;
using System.Linq;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;


namespace TutorialService.Droid
{
    [Service]
    public class ManagerService : Service
    {
        private string TAG = "ManagerService";

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (!IsRunningService())
            {
                Log.Debug(TAG, "Serviço iniciado");
            }
            else
            {
                Log.Debug(TAG, "Serviço já está iniciado");
            }

            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            Log.Debug(TAG, "Serviço encerrado");

            base.OnDestroy();
        }

        private bool IsRunningService()
        {
            var objManager = (ActivityManager)GetSystemService(ActivityService);
            var lstServices = objManager.GetRunningServices(int.MaxValue).Select(
                service => service.Service.ClassName).ToList();
            
            return lstServices.Exists(e => e.Contains(typeof(ManagerService).Name));
        }
    }
}