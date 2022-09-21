using System.ComponentModel.DataAnnotations;

namespace BootcampFinalProject.Models
{
    //The data transfer class of the Product class. All properties in this class are referenced to the required parts.
    public class ProductDto
    {
        //Added required phrase to the beginning of all requests to be received from the user
        public virtual int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string ProductName { get; set; }
        [Required]
        public virtual string BrandName { get; set; }
        [Required]
        [MaxLength(500)]
        public virtual string Description { get; set; }
        [Required]
        public virtual string Colour { get; set; }
        [Required]
        public virtual long Price { get; set; }
        [Required]
        public virtual bool IsOfferable { get; set; }
        [Required]
        public virtual bool IsSold { get; set; }
        [Required]
        public virtual int CategoryId { get; set; }
        [Required]
        public virtual int OwnerId { get; set; }
    }
}
