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
using Android.Content.PM;
using System.Threading.Tasks;
using System.Threading;

namespace SeeLocker.Droid
{
    [Activity(Label = "Quem viu?", Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme.Splash", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.splash_activity);
            
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
            CheckRepositories();
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() =>
            {
                Task.Delay(3000);
            });

            startupWork.ContinueWith(t =>
            {
               StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

        private void CheckRepositories()
        {
            Library.Repository.UserRepository objUserRepository = new Library.Repository.UserRepository();

            // Verifica se a tabela de instâncias existe
            if (!objUserRepository.ExistsTable())
            {
                objUserRepository.CreateTable();
            }
        }
    }
}