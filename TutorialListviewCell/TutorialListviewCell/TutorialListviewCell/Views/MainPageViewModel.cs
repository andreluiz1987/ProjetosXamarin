using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TutorialListviewCell.Views
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            this.ButtonCommand = new Command(this.ButtonClicked);
        }

        ICommand ButtonCommand
        {
            get;
            set;
        }

        public void ButtonClicked()
        {
            App.Current.MainPage.DisplayAlert("", "ButtonClicked", "");
        }
    }
}
