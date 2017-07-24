using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppPreziCalc.Droid.Activities
{
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class SplashPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.splash_activity);
        }
        
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }
        
        async void SimulateStartup()
        {
            await Task.Delay(300);
            StartActivity(new Intent(Application.Context, typeof(FormPCL)));
        }
    }
}