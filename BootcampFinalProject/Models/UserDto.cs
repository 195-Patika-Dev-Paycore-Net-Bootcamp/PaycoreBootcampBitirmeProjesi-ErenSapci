using System;
using System.ComponentModel.DataAnnotations;

namespace BootcampFinalProject.Models
{
    //The data transfer class of the User class.
    public class UserDto
    {
        //Id property
        public virtual int Id { get; set; }
        //Name property
        [Required]
        [MaxLength(500)]
        [Display(Name = "Name")]
        public virtual string Name { get; set; }

        //Surname property
        [Required]
        [MaxLength(500)]
        [Display(Name = "Surname")]
        public virtual string LastName { get; set; }

        //passport property
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [Display(Name = "Password")]
        public virtual string Password { get; set; }

        //Since this field belongs to the email, the required email attribute has been added
        [Required]
        [MaxLength(500)]
        [EmailAddress]
        [Display(Name = "Email")]
        public virtual string Email { get; set; }


    }
}
