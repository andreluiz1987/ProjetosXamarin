using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TutorialListviewCell.Views
{
    public class PageExampleViewModel : ViewModelBase
    {
        public PageExampleViewModel()
        {
            this.ButtonCommand = new Command(this.ButtonClicked);
        }

        private Carro _ItemSelected;
        public Carro SelectedItem
        {
            get
            {
                App.Current.MainPage.DisplayAlert("", _ItemSelected.Modelo, "");
                return _ItemSelected;
            }
            set
            {
                if (_ItemSelected != value)
                {
                    _ItemSelected = value;
                    Notify("ItemSelected");
                }
            }
        }

        ICommand ButtonCommand
        {
            get;
            set;          
        }

        public void ButtonClicked()
        {
            App.Current.MainPage.DisplayAlert("", "ButtonClicked", "");
        }
    }

    public class PageExampleCS : ContentPage
    {
        ListView objListView;
        Button btnComando;

        public PageExampleCS()
        {
            List<Carro> lstCarro = new List<Carro>();
            btnComando = new Button();

            btnComando.Text = "CLIQUE";
            btnComando.SetBinding(Button.CommandProperty, new Binding("ButtonCommand"));

            lstCarro.Add(new Carro { Modelo = "Gol" });
            lstCarro.Add(new Carro { Modelo = "Palio" });
            lstCarro.Add(new Carro { Modelo = "Siena" });

            objListView = new ListView();
            objListView.ItemsSource = lstCarro;
            objListView.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedItem"));
            

            Content = new StackLayout
            {
                Children = {
                   objListView,
                   btnComando
                }
            };

            BindingContext = new PageExampleViewModel();
        }
    }

    public class Carro
    {
        public string Modelo { get; set; }
        public string Ano { get; set; }

        public override string ToString()
        {
            return string.Format(Modelo.ToUpper());
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
