using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPreziCalc.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPreziCalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();

            BindingContext = new IntroViewModel();
        }

        async void OnClickAbout(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }

        async void OnClickGeneral(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new GeneralPage());
        }
    }
}