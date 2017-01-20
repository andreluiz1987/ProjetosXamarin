using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialDepService.Interface;
using Xamarin.Forms;

namespace TutorialDepService.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnGPS.Clicked += OnGPSClicked;
        }

        private async void OnGPSClicked(object sender, EventArgs e)
        {
            lblGpsSearch.Text = "Buscando posição...";

            var objCoordinate = await DependencyService.Get<IGps>().GetPosition();

            if (objCoordinate != null)
            {
                lblGpsSearch.Text = "Posição válida!";
                lblGpsLatitude.Text = "Latitude: " + objCoordinate.Latitude.ToString();
                lblGpsLongitude.Text = "Longitude: " + objCoordinate.Longitude.ToString();
            }
        }
    }
}
