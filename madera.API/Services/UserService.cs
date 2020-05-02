using madera.API.Helpers;
using madera.API.Models;
using madera.API.Models.FormRequest;
using madera.API.Models.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace madera.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly MaderaContext _context;

        public UserService(IOptions<AppSettings> appSettings, MaderaContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateToken Authenticate(AuthenticateModel authenticateModel)
        {
            Utilisateur utilisateur = _context.Utilisateur.Include(u => u.Role).SingleOrDefault(u => u.Email == authenticateModel.Email);

            if (utilisateur == null) return null;

            if (BCrypt.Net.BCrypt.Verify(authenticateModel.Password, utilisateur.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, utilisateur.Id.ToString())
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new AuthenticateToken
                {
                    Utilisateur = utilisateur,
                    Token = tokenHandler.WriteToken(token)
                };
            }

            return null;
        }
    }
}
