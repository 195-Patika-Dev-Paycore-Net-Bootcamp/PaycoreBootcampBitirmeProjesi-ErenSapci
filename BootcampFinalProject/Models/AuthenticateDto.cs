using System.ComponentModel.DataAnnotations;

namespace BootcampFinalProject.Models
{
    //The data transfer class where the components that the user is entered are kept.
    public class AuthenticateDto
    {
        [Required]
        [EmailAddress]
        public virtual string Email{ get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public virtual string Password { get; set; }
    }
}
