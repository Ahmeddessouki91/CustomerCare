using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources.UserResouce
{
    public class UserSaveResource : UserUpdateResouce
    {
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "You have to specify at least 6 characters for password")]
        public string Password { get; set; }
    }
}