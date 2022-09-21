namespace BootcampFinalProject.Models
{
    public class OfferDto
    {
        //The area where the data transfer objects where the offers will be kept are placed
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual long UserOffer { get; set; }
        public virtual string OfferStatus { get; set; }
        public virtual int ProductId { get; set; }
    }
}
