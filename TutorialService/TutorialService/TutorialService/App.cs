using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TutorialService
{
    public class App : Application
    {
        Button btnStartService;
        Button btnStopService;

        public App()
        {
            btnStartService = new Button
            {
                Text = "Iniciar serviço"                
            };
            btnStartService.Clicked += StarService_Command;

            btnStopService = new Button
            {
                Text = "Parar serviço"
            };
            btnStopService.Clicked += StopService_Command;
            // The root page of your application
            var content = new ContentPage
            {
                Title = "TutorialService",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Padding = new Thickness(20, 50, 20, 20),
                    Children = { btnStartService, btnStopService }                    
                }
            };

            MainPage = new NavigationPage(content);
        }

        private void StopService_Command(object sender, EventArgs e)
        {
            DependencyService.Get<Interface.IServices>().StopService();
        }

        private void StarService_Command(object sender, EventArgs e)
        {
            DependencyService.Get<Interface.IServices>().StartService();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
