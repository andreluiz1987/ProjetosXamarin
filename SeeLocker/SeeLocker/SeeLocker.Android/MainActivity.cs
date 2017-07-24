using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace SeeLocker.Droid
{
    [Activity(Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);

            Acr.UserDialogs.UserDialogs.Init(this);

            LoadApplication(new SeeLocker.App.App());
        }
        
        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}

