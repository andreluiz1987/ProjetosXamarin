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

[assembly: Xamarin.Forms.Dependency(typeof(TutorialService.Droid.DroidService))]

namespace TutorialService.Droid
{
    public class DroidService : TutorialService.Interface.IServices
    {
        public void StartService()
        {
            Xamarin.Forms.Forms.Context.StartService(new Intent(Xamarin.Forms.Forms.Context, typeof(ManagerService)));
        }

        public void StopService()
        {
            Xamarin.Forms.Forms.Context.StopService(new Intent(Xamarin.Forms.Forms.Context, typeof(ManagerService)));
        }
    }
}