using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TutorialListviewCell.Controls
{
    class ImageButton : Image
    {
        public static BindableProperty CommandProperty =
            BindableProperty.Create<ImageButton, ICommand>(bp => bp.Command, default(ICommand));

        public ICommand Command {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }

        }

        public ImageButton()
        {
            var gesto = new TapGestureRecognizer();
            gesto.Tapped += (sender, e) =>
            {
                this.Command.Execute(null);
            };

            this.GestureRecognizers.Add(gesto);
        }
    }
}
