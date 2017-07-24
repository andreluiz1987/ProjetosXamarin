using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppPreziCalc.Model;

namespace AppPreziCalc.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Command CalcPreziChildCommand { get; }
        public Command CalcPreziAdultCommand { get; }

        public MainViewModel()
        {
            CalcPreziChildCommand = new Command(ExecuteChildCommand);
            CalcPreziAdultCommand = new Command(ExecuteAdultCommand);
        }
        
        private async void ExecuteChildCommand()
        {
            await PushAsync<MedicineViewModel>(CalcMedicine.Type.CHILD);
        }

        private async void ExecuteAdultCommand()
        {
            await PushAsync<MedicineViewModel>(CalcMedicine.Type.ADULT);
        }
    }
}
