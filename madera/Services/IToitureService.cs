using madera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public interface IToitureService
    {
        Task<List<Toiture>> GetAllToitureAsync();
    }
}
