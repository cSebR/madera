using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class DevisService : IDevisService
    {
        private readonly SQLiteAsyncConnection _database;

        public DevisService()
        {
            _database = App.Database._database;
        }
        public Task<List<Devis>> GetAllDevisAsync()
        {
            return _database.Table<Devis>().ToListAsync();
        }

        public Task<int> AddDevisAsync(Devis devis)
        {
            return _database.InsertAsync(devis);
        }

    }
}
