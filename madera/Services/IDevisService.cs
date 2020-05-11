using madera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public interface IDevisService
    {
        Task<List<Devis>> GetAllDevisAsync();
        Task<int> AddDevisAsync(Devis devis);
    }
}
