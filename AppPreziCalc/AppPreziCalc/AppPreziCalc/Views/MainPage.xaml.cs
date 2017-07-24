using AppPreziCalc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPreziCalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
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