using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using madera.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace madera.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ClientModel>().Wait();
            _database.CreateTableAsync<ProjetModel>().Wait();
        }

        public Task<List<ClientModel>> GetPeopleAsync()
        {
            return _database.Table<ClientModel>().ToListAsync();
        }

        public Task<List<ProjetModel>> GetProjetAsync()
        {
            return _database.GetAllWithChildrenAsync<ProjetModel>();
        }

        public Task<int> SaveProjetAsync(ProjetModel projet)
        {
            return _database.InsertAsync(projet);
        }

        public Task<int> SaveClientAsync(ClientModel client)
        {
            return _database.InsertAsync(client);
        }
    }
}
