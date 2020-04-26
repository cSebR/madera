using madera.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace madera.Services
{
    public interface IAuthService
    {
        Task<HttpStatusCode> Login(AuthModel authModel);
    }
}
