using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class PanneauService : IPanneauService
    {
        private readonly SQLiteAsyncConnection _database;

        // -------------------------------------------------------------------

        public PanneauService()
        {
            _database = App.Database._database;
        }

        // -------------------------------------------------------------------

        public Task<List<Panneau>> GetAllPanneauAsync()
        {
            return _database.Table<Panneau>().ToListAsync();
        }
    }
}
