
namespace madera.API.Models.Response
{
    public class AuthenticateToken
    {
        public Utilisateur Utilisateur { get; set; }
        public string Token { get; set; }
    }
}
