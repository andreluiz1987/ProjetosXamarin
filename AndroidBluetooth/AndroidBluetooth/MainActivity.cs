using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using System;
using System.Collections.Generic;

namespace AndroidBluetooth
{
    [Activity(Label = "AndroidBluetooth", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView lstData;
        private BluetoothManager objBluetoothManager;
        private String strData = "";
        private List<string> DataList;
        private ArrayAdapter objAdapter;

        public Activity GetActivity { get { return this; } }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            lstData = FindViewById<ListView>(Resource.Id.lstData);

            Init();
        }

        private void Init()
        {
            DataList = new List<string>();
            objBluetoothManager = new BluetoothManager();
            objAdapter = new ArrayAdapter<string>(GetActivity, Android.Resource.Layout.SimpleListItem1, DataList);

            objBluetoothManager.GetPairedDevices();
            lstData.Adapter = objAdapter;

            ReceiveData();
        }

        private void ReceiveData()
        {
            Thread thread = new Thread(() =>
            {
                char chData;

                while (true)
                {
                    chData = objBluetoothManager.GetDataFromDevice();

                    if (chData != '\r')
                    {
                        strData += chData;
                    }
                    else
                    {
                        updateDisplay(strData);                        
                        strData = "";
                    }

                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        private void updateDisplay(string strData)
        {
            RunOnUiThread(() => {
                objAdapter.Add(strData);
            });                
        }
    }    
}
