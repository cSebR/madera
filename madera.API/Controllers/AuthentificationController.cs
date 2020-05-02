using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using madera.API.Models.FormRequest;
using madera.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace madera.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private IUserService _userService;

        public AuthentificationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model);

            if (user == null)
                return BadRequest(new { message = "Identifiants incorrects, veuillez vérifier votre email et mot de passe." });

            return Ok(user);
        }
    }
}