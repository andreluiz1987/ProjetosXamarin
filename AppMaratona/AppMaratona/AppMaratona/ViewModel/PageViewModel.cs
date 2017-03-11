using AppMaratona.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using AppMaratona.Model.Service;

namespace AppMaratona.ViewModel
{
    public class PageViewModel : ViewModelBase
    {
        private Boolean blnIsBusy;
        private ICommand icRefreshCommand;
        public ObservableCollection<Contacts> ListContacts { get; set; }

        public ICommand RefreshCommand
        {
            get { return icRefreshCommand ?? (icRefreshCommand = new Command(async () => await LoadDataRefreshCommand())); }
        }

        public ICommand AddCommand
        {
            get { return new Command(async () => await AddDataCommand()); }
        }

        public ICommand UpdateCommand
        {
            get { return new Command(async () => await UpdateDataCommand()); }
        }

        public bool IsBusy
        {
            get { return blnIsBusy; }
            set
            {
                blnIsBusy = value;
            }
        }

        public PageViewModel()
        {
            ListContacts = new ObservableCollection<Contacts>();

            Load();
        }

        async Task LoadDataRefreshCommand()
        {
            IsBusy = true;

            await Task.Delay(3000);

            IsBusy = false;
        }

        async Task AddDataCommand()
        {
            var objContacts = new Contacts { Name = "André", Code = "01221" };

            var objService = new AzureService<Contacts>();
            await objService.Insert(objContacts);
        }

        async Task UpdateDataCommand()
        {
            var lista = await GetContacts();
            ListContacts.Clear();

            foreach (Contacts contato in lista)
            {
                ListContacts.Add(contato);
            }
        }

        private void Load()
        {
            //ListContacts.Add(new ContactsModel { Name = "André", Code="01221" });
        }

        public async Task<List<Contacts>> GetContacts()
        {
            var objService = new AzureService<Contacts>();
            var objItems = await objService.GetTable();
            return objItems.ToList();
        }
    }
}
