using madera.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            Clients = App.Database.GetPeopleAsyncClient().Result;
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
