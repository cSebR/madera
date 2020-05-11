using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class BardageService : IBardageService
    {
        private readonly SQLiteAsyncConnection _database;

        // -------------------------------------------------------------------

        public BardageService()
        {
            _database = App.Database._database;
        }

        // -------------------------------------------------------------------

        public Task<List<Bardage>> GetAllBardageAsync()
        {
            return _database.Table<Bardage>().ToListAsync();
        }
    }
}
