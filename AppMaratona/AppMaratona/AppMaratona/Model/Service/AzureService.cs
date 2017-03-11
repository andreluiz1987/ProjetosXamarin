using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace AppMaratona.Model.Service
{
    public class AzureService<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<Contacts> Table;

        public AzureService()
        {
            string MyAppServiceURL = "http://demodeveloperxamarin.azurewebsites.net";
            Client = new MobileServiceClient(MyAppServiceURL);
            Table = Client.GetTable<Contacts>();
        }

        public Task<IEnumerable<Contacts>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }

        public async Task Insert(Contacts objContacts)
        {
            await Table.InsertAsync(objContacts);
        }
    }
}
