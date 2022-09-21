using System.ComponentModel.DataAnnotations;

namespace BootcampFinalProject.Base.Token
{
    public class TokenRequest
    {
        [Required]
        [EmailAddress]
        [MaxLength(200)]
        [Display(Name = "Email")]
        public string Email  { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
