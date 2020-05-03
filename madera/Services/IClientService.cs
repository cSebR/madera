using madera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public interface IClientService
    {
        Task<int> AddClientAsync(ClientModel clientModel);
        Task<int> UpdateClientAsync(ClientModel clientModel);
    }
}
