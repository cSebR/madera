using madera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public class PlancherService : IPlancherService
    {
        private readonly SQLiteAsyncConnection _database;

        // -------------------------------------------------------------------

        public PlancherService()
        {
            _database = App.Database._database;
        }

        // -------------------------------------------------------------------

        public Task<List<Plancher>> GetAllPlancherAsync()
        {
            return _database.Table<Plancher>().ToListAsync();
        }
    }
}
