using System;
using System.Linq;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace SeeLocker.Droid.Lib.Services
{
    [Service(Exported = true)]
    public class LockService : Service
    {
        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            LockerBroadcastReceiver objReceiver = new LockerBroadcastReceiver();

            RegisterReceiver(objReceiver, new IntentFilter(Android.Content.Intent.ActionUserPresent));

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();            
        }
        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }
    }
}