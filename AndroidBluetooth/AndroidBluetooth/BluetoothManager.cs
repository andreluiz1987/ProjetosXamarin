using System;
using Android.Bluetooth;
using Java.IO;
using Java.Util;

namespace AndroidBluetooth
{
    class BluetoothManager
    {
        private string UUIDUniversal = "00001101-0000-1000-8000-00805F9B34FB";
        private BluetoothDevice objResult;
        private BluetoothSocket objSocket;
        private BufferedReader objReader;

        private System.IO.Stream objStream;
        private InputStreamReader objStreamReader;

        public BluetoothManager()
        {
            objReader = null;
        }

        private UUID GetUUID()
        {
            return UUID.FromString(UUIDUniversal);
        }

        private void OpenDevice(BluetoothDevice objDevice)
        {
            try
            {
                objSocket = objDevice.CreateRfcommSocketToServiceRecord(GetUUID());
                objSocket.Connect();

                objStream = objSocket.InputStream;
                objStreamReader = new InputStreamReader(objStream);
                
            }
            catch (Exception ex)
            {
                Close(objSocket);
                Close(objStream);
                Close(objStreamReader);
                throw ex;
            }
        }

        private void Close(IDisposable objDispose)
        {
            try
            {
                if (objDispose != null)
                {
                    objDispose.Dispose();
                    objDispose = null;
                }
            }
            catch (Exception)
            {
            }

        }

        public char GetDataFromDevice()
        {
            char value = ' ';

            if (objStreamReader != null)
            {
                value = (char)objStreamReader.Read();
            }

            return value;
        }

        public void GetPairedDevices()
        {
            try
            {
                BluetoothAdapter objAdapter = BluetoothAdapter.DefaultAdapter;

                var objDevicesList = objAdapter.BondedDevices;

                if (objDevicesList != null && objDevicesList.Count > 0)
                {
                    foreach (BluetoothDevice objDevice in objDevicesList)
                    {
                        OpenDevice(objDevice);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}