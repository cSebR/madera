using madera.Models;
using madera.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class ClientFormViewModel : BaseViewModel
    {
        private readonly ClientService ClientService = new ClientService();

        // -------------------------------------------------------------------

        public ClientFormViewModel()
        {
            Title = "Création d'un client";
            ClientModel = new ClientModel();
        }

        // -------------------------------------------------------------------

        /**
         * Client à créer
         */
        private ClientModel _clientModel;
        public ClientModel ClientModel
        {
            get
            {
                return _clientModel;
            }

            set
            {
                _clientModel = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        /**
         * Commande lors d'une action sur le bouton "Sauvegarder"
         */
        private Command _btnAddClient;
        public Command BtnAddClient
        {
            get
            {
                if (_btnAddClient == null)
                {
                    _btnAddClient = new Command(async () =>
                    {
                        await ClientService.AddClientAsync(_clientModel);
                    });
                }
                return _btnAddClient;
            }
        }

        
    }
}
