using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class ClientService : IClientService
    {
        private readonly SQLiteAsyncConnection _database;

        // -------------------------------------------------------------------

        public ClientService()
        {
            _database = App.Database._database;
        }

        // -------------------------------------------------------------------

        /**
         * Récupère tous les clients
         */
        public Task<List<ClientModel>> GetAllClientAsync()
        {
            return _database.Table<ClientModel>().ToListAsync();
        }

        /**
         * Créé un client
         */
        public Task<int> AddClientAsync(ClientModel clientModel)
        {
            return _database.InsertAsync(clientModel);
        }

        /**
         * Modifie un client
         */
        public Task<int> UpdateClientAsync(ClientModel clientModel)
        {
            return _database.UpdateAsync(clientModel);
        }

        /**
         * Supprime un client
         */
        public Task<int> RemoveClientAsync(ClientModel clientModel)
        {
            return _database.DeleteAsync(clientModel);
        }
    }
}
