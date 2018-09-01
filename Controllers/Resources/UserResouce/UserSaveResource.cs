using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources.UserResouce
{
    public class UserSaveResource 
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6,
        ErrorMessage = "You have to specify at least 6 characters for password")]
        public string Password { get; set; }
    }
}