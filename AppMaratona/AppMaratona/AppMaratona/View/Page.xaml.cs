using AppMaratona.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMaratona.View
{
    public partial class Page : ContentPage
    {
        public Page()
        {
            InitializeComponent();
            this.BindingContext = new PageViewModel();
        }
    }
}
