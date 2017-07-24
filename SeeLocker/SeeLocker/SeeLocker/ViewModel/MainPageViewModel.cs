using Acr.UserDialogs;
using SeeLocker.Library.Repository;
using SeeLocker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeeLocker.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> obsData;

        public ICommand ButtonCommand { protected set; get; }

        private string FInitialDate;
        public string InitialDate
        {
            get { return FInitialDate; }
            set
            {
                FInitialDate = value;
                OnPropertyChanged("InitialDate");
            }
        }

        private string FEndDate;
        public string EndDate
        {
            get { return FEndDate; }
            set
            {
                FEndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public ObservableCollection<UserModel> ListItens
        {
            get
            {
                return obsData;
            }
            set
            {
                obsData = value;
                OnPropertyChanged("ListItens");
            }
        }

        public MainPageViewModel()
        {
            ListItens = new ObservableCollection<UserModel>();

            DoSubscribe();

            this.ButtonCommand = new Command(this.GetGridView);

            GetGridView();
        }

        private void GetGridView()
        {
            DateTime strInitialDate, strEndDate;

            UserRepository objUserRepository = new UserRepository();

            try
            {
                using (var objUserDialog = UserDialogs.Instance.Loading("Carregando...", maskType: Acr.UserDialogs.MaskType.Black))
                {
                    ListItens.Clear();

                    strInitialDate = (String.IsNullOrEmpty(InitialDate) ? new DateTime() : Convert.ToDateTime(InitialDate + " 00:00:00"));
                    strEndDate = (String.IsNullOrEmpty(EndDate) ? new DateTime() : Convert.ToDateTime(EndDate + " 23:59:59"));

                    var lstLockers = objUserRepository.GetAll(strInitialDate, strEndDate);

                    if (lstLockers.Count > 0)
                    {
                        //adicopna a lista na coleção
                        foreach (UserModel onData in lstLockers)
                        {
                            ListItens.Add(onData);
                        }

                        UserDialogs.Instance.Toast("Registros carregados com sucesso!", TimeSpan.FromSeconds(3));
                    }
                    else
                    {
                        UserDialogs.Instance.Toast("Não existem registros salvos.", TimeSpan.FromSeconds(3));
                    }

                    InitialDate = "";
                    EndDate = "";

                    objUserDialog.Hide();
                }                
            }
            catch (Exception)
            {
                
            }           
        }

        public void DoSubscribe()
        {
            MessagingCenter.Subscribe<MainPageViewModel>(this, "Change", (sender) =>
            {
                UserRepository objUserRepository = new UserRepository();

                var lstLockers = objUserRepository.GetAll(new DateTime(), new DateTime());

                ListItens = new ObservableCollection<UserModel>();

                if (lstLockers.Count > 0)
                {
                    //adicopna a lista na coleção
                    foreach (UserModel onData in lstLockers)
                    {
                        ListItens.Add(onData);
                    }
                }
            });
        }
    }
}
