using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialListviewCell.Model;
using Xamarin.Forms;

namespace TutorialListviewCell.Views
{
    public partial class PageDetail : ContentPage
    {
        public PageDetail(Animal objAnimal)
        {
            InitializeComponent();

            imgAnimal.Source = objAnimal.Image;
            lblAnimalName.Text = "Animal: " + objAnimal.Name;
            lblFamily.Text = objAnimal.Family;
        }
    }
}
