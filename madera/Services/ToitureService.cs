using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class ToitureService : IToitureService
    {
        private readonly SQLiteAsyncConnection _database;

        // -------------------------------------------------------------------

        public ToitureService()
        {
            _database = App.Database._database;
        }

        // -------------------------------------------------------------------

        public Task<List<Toiture>> GetAllToitureAsync()
        {
            return _database.Table<Toiture>().ToListAsync();
        }
    }
}
