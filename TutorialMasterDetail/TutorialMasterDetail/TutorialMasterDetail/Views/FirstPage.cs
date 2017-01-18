using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TutorialMasterDetail.Views
{
    public class FirstPage : ContentPage
    {
        public FirstPage()
        {
            Title = "Página 1";
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Página 1" }
                }
            };
        }
    }
}
