using System.Collections.Generic;

namespace BootcampFinalProject.Entities.Model
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public  virtual string BrandName { get; set; }
        public virtual string Colour { get; set; }
        public virtual long Price { get; set; }
        public virtual bool IsOfferable  { get; set; }
        public virtual bool IsSold { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int OwnerId { get; set; }
    }
}
