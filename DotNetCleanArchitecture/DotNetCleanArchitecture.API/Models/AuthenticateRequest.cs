using System.ComponentModel.DataAnnotations;

namespace DotNetCleanArchitecture.API.Models
{
    public class IAuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}