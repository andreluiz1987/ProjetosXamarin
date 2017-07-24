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
using Xamarin.Forms;

[assembly: Dependency(typeof(SeeLocker.Droid.Lib.DependencyService.DateTime))]

namespace SeeLocker.Droid.Lib.DependencyService
{
    public class DateTime : Java.Lang.Object, SeeLocker.Library.Interface.IDatePicker
    {
        private Entry entAux = new Entry();
        private string strValue;
        private System.DateTime dteNow;

        public DateTime()
        {
        }

        #region IDatePicker implementation

        public void ShowDatePicker(Xamarin.Forms.Entry edtDatePicker)
        {
            var context = Forms.Context;
            entAux = edtDatePicker;
            System.DateTime dteToday = System.DateTime.Today;
            DatePickerDialog dialog = new DatePickerDialog(context, EventHandler_DatePicker, dteToday.Year, dteToday.Month - 1, dteToday.Day);
            dialog.DatePicker.MinDate = dteToday.Millisecond;
            dialog.Show();
        }

        public void EventHandler_DatePicker(object sender, DatePickerDialog.DateSetEventArgs e)
        {

            if (e.Date.Day != System.DateTime.DaysInMonth(e.Date.Year, e.Date.Month))
                dteNow = e.Date;
            else
                dteNow = e.Date.AddDays(1).AddMonths(1).AddDays(-1);

            entAux.Text = dteNow.ToString("d");
            strValue = entAux.Text;
            dteNow = e.Date;
        }

        #endregion
    }
}
