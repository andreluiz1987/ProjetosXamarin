using AppPreziCalc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPreziCalc.ViewModel
{
    public class MedicineViewModel : BaseViewModel
    {
        private bool blnPanelResult;
        private CalcMedicine.Type type;
        private string strTextButton;
        private string entWeigth;

        public string Weigth_Text
        {
            get { return entWeigth; }
            set { SetProperty(ref entWeigth, value); }
        }

        private string strPreziResult;

        public string PreziResult_Text
        {
            get { return strPreziResult; }
            set { SetProperty(ref strPreziResult, value); }
        }

        public string btnText
        {
            get { return strTextButton; }
            set { SetProperty(ref strTextButton, value); }
        }

        public bool VisiblePanel
        {
            get { return blnPanelResult; }
            set { SetProperty(ref blnPanelResult, value); }
        }


        public Command Prezi_Command { get; }


        public MedicineViewModel(CalcMedicine.Type type)
        {
            VisiblePanel = false;
            btnText = AppPreziCalc.Resources.Default.Button_Calculate_Text;
            Prezi_Command = new Command(ExecuteCalcCommand);

            this.type = type;
        }

        private void ExecuteCalcCommand()
        {
            CalcMedicine objCalc = new CalcMedicine();

            if (btnText == AppPreziCalc.Resources.Default.Button_Clear_Text)
            {
                Weigth_Text = "";
                PreziResult_Text = "";
                btnText = AppPreziCalc.Resources.Default.Button_Calculate_Text;
                VisiblePanel = false;
            }
            else
            {
                if (String.IsNullOrEmpty(Weigth_Text))
                {
                    App.Current.MainPage.DisplayAlert(AppPreziCalc.Resources.Default.Alert_Text, AppPreziCalc.Resources.Default.Message_WarningReportWeight_Text, "OK");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("{0}", Convert.ToDouble(Weigth_Text, System.Globalization.CultureInfo.InvariantCulture));
                    PreziResult_Text = objCalc.CalcDosage(Convert.ToDouble(Weigth_Text, System.Globalization.CultureInfo.InvariantCulture), type).ToString();
                    VisiblePanel = true;
                    btnText = AppPreziCalc.Resources.Default.Button_Clear_Text;
                }
            }
        }
    }
}
