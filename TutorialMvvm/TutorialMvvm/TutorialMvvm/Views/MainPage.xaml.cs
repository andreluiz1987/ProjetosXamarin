using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TutorialMvvm.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnApply.Clicked += ButtonApply_Clicked;
        }

        private void ButtonApply_Clicked(object sender, EventArgs e)
        {
            lblField.Text = entName.Text;            
        }
    }
}
