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
using SeeLocker.Model;
using SeeLocker.Droid.Lib;

namespace SeeLocker.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Android.Content.Intent.ActionUserPresent })]
    public class LockerBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            try
            {
                if (!Xamarin.Forms.Forms.IsInitialized)
                {
                    global::Xamarin.Forms.Forms.Init(context, new Bundle());
                }

                UserModel objUser = new UserModel();

                objUser.LockDateCurrent = DateTime.Now.ToString("dd/MM/yyyy HH:mmm");
                objUser.LockDate = DateTime.Now;
                objUser.Save(UserModel.SaveType.Insert);

                //Inicia o serviço da webCam
                //CameraProvider.Initialize();

                //Chama o metodo que captura a foto
                //var objWebCam = new CameraProvider(context, CameraProvider.objCamera);
                // objWebCam.TakePicture();

            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}