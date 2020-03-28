using madera.Models;
using madera.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace madera.Test.Mocks
{
    public class MockAuthService : IAuthService
    {
        public Task<HttpStatusCode> Login(Utilisateur utilisateur)
        {
            if (utilisateur.utilisateur_email.Equals("test@test.com") && utilisateur.utilisateur_password.Equals("123456"))
                return Task.FromResult(HttpStatusCode.OK);
            return Task.FromResult(HttpStatusCode.BadRequest);
        }
    }
}
