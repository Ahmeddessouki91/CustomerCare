using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources.UserResouce
{
    public class LoginResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}