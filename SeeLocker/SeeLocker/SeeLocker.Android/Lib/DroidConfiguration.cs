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
using SeeLocker.Library.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SeeLocker.Droid.Lib.DroidConfiguration))]

namespace SeeLocker.Droid.Lib
{
    class DroidConfiguration : IConfiguration
    {
        #region Variáveis
        private string strDirectoryDataBase;
        private SQLite.Net.Interop.ISQLitePlatform objPlatformDevice;
        #endregion

        #region Propriedades
        public string Directory
        {
            get
            {
                if (string.IsNullOrEmpty(strDirectoryDataBase))
                {
                    strDirectoryDataBase = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return strDirectoryDataBase;
            }
        }

        public SQLite.Net.Interop.ISQLitePlatform PlatformDevice
        {
            get
            {
                if (objPlatformDevice == null)
                {
                    objPlatformDevice = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }

                return objPlatformDevice;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Initializes a new instance of the <see cref="DroidConfiguration"/> class.
        /// </summary>
        public DroidConfiguration() { }

        #endregion
    }
}

