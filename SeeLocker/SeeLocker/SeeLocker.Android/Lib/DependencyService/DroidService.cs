using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SeeLocker.Droid.Lib.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SeeLocker.Droid.Lib.DependencyService.DroidService))]

namespace SeeLocker.Droid.Lib.DependencyService
{
    public class DroidService : SeeLocker.Library.Interface.IServices
    {
        public void StartService()
        {
            Xamarin.Forms.Forms.Context.StartService(new Intent(Xamarin.Forms.Forms.Context, typeof(LockService)));
        }

        public void StopService()
        {
            Xamarin.Forms.Forms.Context.StopService(new Intent(Xamarin.Forms.Forms.Context, typeof(LockService)));
        }
    }
}