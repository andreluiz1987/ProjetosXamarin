using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TutorialMasterDetail.Views
{
    public class SecondPage : ContentPage
    {
        public SecondPage()
        {
            Title = "Página 2";
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Página 2" }
                }
            };
        }
    }
}
