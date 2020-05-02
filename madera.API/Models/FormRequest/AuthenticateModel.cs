using System.ComponentModel.DataAnnotations;

namespace madera.API.Models.FormRequest
{
    public class AuthenticateModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
