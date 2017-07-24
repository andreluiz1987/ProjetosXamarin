using SeeLocker.Library.Repository;
using SeeLocker.Model;
using SeeLocker.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeLocker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurationPage : ContentPage
    {
        private UserRepository objUserRepository;

        public ConfigurationPage()
        {
            MainPageViewModel objMainViewModel;
            Title = "Configurações";

            InitializeComponent();

            TapGestureRecognizer objGesto = new TapGestureRecognizer();

            objGesto.Tapped += async (s, e) =>
            {
                var result = await App.App.Current.MainPage.DisplayAlert("Aviso", "Deseja apagar todos os registros?", "Sim", "Não");

                if (result)
                {
                    var objReturn = UserModel.DeleteAll();

                    if(objReturn > 0)
                    {
                        await App.App.Current.MainPage.DisplayAlert("Aviso", "Registros apagados com sucesso!", "OK");

                        objMainViewModel = new MainPageViewModel();
                        //objMainViewModel.GetGridView();

                        MessagingCenter.Send<MainPageViewModel>(objMainViewModel, "Change");
                    }
                }
            };

            stlClearData.GestureRecognizers.Add(objGesto);

            objUserRepository = new UserRepository();

            ldlCount.Text = objUserRepository.GetCount().ToString();
        }
    }
}
