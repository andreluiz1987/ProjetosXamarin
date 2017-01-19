using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TutorialToolbarItem.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnClickButtonOne(object sender, EventArgs e)
        {
            var blnResponse = await App.Current.MainPage.DisplayAlert("Título", "Coloque uma mensagem aqui..", "Ok", "Cancelar");

            string strMessage = (blnResponse ? "Apertou Ok!" : "Apertou Cancelar");
            await App.Current.MainPage.DisplayAlert("Título", strMessage, "Ok");
        }

        async void OnClickButtonTwo(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("Título", "Alert de confirmação", "Ok");
        }

        async void OnClickButtonThree(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("Título", "Pesquisa", "Ok");
        }
    }
}
