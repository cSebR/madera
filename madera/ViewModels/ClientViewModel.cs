using madera.Models;
using madera.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        private readonly ClientService ClientService = new ClientService();

        // -------------------------------------------------------------------

        public ClientViewModel()
        {
            Title = "Liste des clients";
            Init();
        }

        // -------------------------------------------------------------------

        public void Init()
        {
            Clients = ClientService.GetAllClientAsync().Result;
        }

        // -------------------------------------------------------------------

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
