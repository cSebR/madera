using madera.API.Models.FormRequest;
using madera.API.Models.Response;

namespace madera.API.Services
{
    public interface IUserService
    {
        public AuthenticateToken Authenticate(AuthenticateModel authenticateModel);
    }
}
