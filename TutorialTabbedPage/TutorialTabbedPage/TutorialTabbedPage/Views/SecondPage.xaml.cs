using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TutorialTabbedPage.Views
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        async void OnChangePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThirdPage());
        }
    }
}
