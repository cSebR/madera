using madera.Models;
using madera.Services;
using madera.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class FicheClientViewModel : BaseViewModel
    {
        private readonly ClientService ClientService = new ClientService();

        // -------------------------------------------------------------------

        public FicheClientViewModel(ClientModel clientModel)
        {
            ClientModel = clientModel;
        }

        // --------------------------------------------------------------------

        /**
         * Client à éditer
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
        private Command _btnUpdateClient;
        public Command BtnUpdateClient
        {
            get
            {
                if (_btnUpdateClient == null)
                {
                    _btnUpdateClient = new Command( async () =>
                    {
                        await ClientService.UpdateClientAsync(_clientModel);
                    },
                    () => !string.IsNullOrWhiteSpace(ClientModel.Nom) && !string.IsNullOrWhiteSpace(ClientModel.Prenom)
                    );
                }
                return _btnUpdateClient;
            }
        }  
        
        /**
         * Commande lors d'une action sur le bouton "Sauvegarder"
         */
        private Command _btnRemoveClient;
        public Command BtnRemoveClient
        {
            get
            {
                if (_btnRemoveClient == null)
                {
                    _btnRemoveClient = new Command( async () =>
                    {
                        DisplayAlert("Suppression d'un client", "Êtes-vous sûr de vouloir supprimer le client?", "Oui", "Non");
                    });
                }
                return _btnRemoveClient;
            }
        }

        public async Task RemoveClientAsync()
        {
            await ClientService.RemoveClientAsync(_clientModel);
        }
    }
}
