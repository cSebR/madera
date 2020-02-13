using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using madera.Models;
using SQLite;

namespace madera.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ClientModel>().Wait();
        }

        public Task<List<ClientModel>> GetPeopleAsync()
        {
            return _database.Table<ClientModel>().ToListAsync();
        }

        public Task<int> SaveClientAsync(ClientModel client)
        {
            return _database.InsertAsync(client);
        }
    }
}
