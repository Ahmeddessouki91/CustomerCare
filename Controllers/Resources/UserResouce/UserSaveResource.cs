using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources.UserResouce
{
    public class UserSaveResource
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public bool Deactive { get; set; }
    }
}