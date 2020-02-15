using madera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.ViewModels
{
    public class ClientViewModel :BaseViewModel
    {
        public ClientViewModel()
        {
            Title = "Client";
            Init();
        }

        public void Init()
        {
            Clients = App.Database.GetPeopleAsync().Result;
        }

        private List<ClientModel> clients;
        public List<ClientModel> Clients
        {
            get
            {
                return clients;
            }

            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }
    }
}
