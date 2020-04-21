using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using madera.Models;
using SQLite;

namespace madera.Services
{
    public class Database
    {
        public readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Role>().Wait();
            _database.CreateTableAsync<Utilisateur>().Wait();
            _database.CreateTableAsync<ClientModel>().Wait();
			_database.CreateTableAsync<ProjetModel>().Wait();
            _database.CreateTableAsync<Devis>().Wait();
            _database.CreateTableAsync<Remise>().Wait();
            _database.CreateTableAsync<DossierTechnique>().Wait();
            _database.CreateTableAsync<TypeEtat>().Wait();
            _database.CreateTableAsync<Plan>().Wait();
            _database.CreateTableAsync<Module>().Wait();
        }

        public Task<List<ClientModel>> GetPeopleAsync()
        {
            return _database.Table<ClientModel>().ToListAsync();
        }

        public Task<int> SaveClientAsync(ClientModel client)
        {
            return _database.InsertAsync(client);
        }

        public Task<List<ProjetModel>> GetProjetModelAsync()
        {
            return _database.Table<ProjetModel>().ToListAsync();
        }

        public Task<int> SaveProjetAsync(ProjetModel projet)
        {
            return _database.InsertAsync(projet);
        }
    }
}
