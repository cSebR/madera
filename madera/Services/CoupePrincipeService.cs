using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class CoupePrincipeService : ICoupePrincipeService
    {
        private readonly SQLiteAsyncConnection _database;

        // -------------------------------------------------------------------

        public CoupePrincipeService()
        {
            _database = App.Database._database;
        }

        // -------------------------------------------------------------------
        public Task<List<CoupePrincipe>> GetAllCoupePrincipeAsync()
        {
            return _database.Table<CoupePrincipe>().ToListAsync();
        }
    }
}
